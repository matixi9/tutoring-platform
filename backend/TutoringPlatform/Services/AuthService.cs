using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TutoringPlatform.Data;
using TutoringPlatform.DTOs;
using TutoringPlatform.Models;

namespace TutoringPlatform.Services;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterDto registerDto);
    Task<string> LoginAsync(LoginDto loginDto);
}

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IConfiguration _configuration;

    public AuthService(ApplicationDbContext context, IPasswordHasher passwordHasher, IConfiguration configuration)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _configuration = configuration;
    }

    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {
        if (await _context.Users.AnyAsync(u => u.Email == registerDto.Email))
            throw new Exception("Email already exists");

        if (!Enum.TryParse<UserRole>(registerDto.Role, true, out var role))
            throw new Exception("Invalid role, must be either student or tutor");

        var user = new User
        {
            Email = registerDto.Email,
            Name = registerDto.Name,
            Password = _passwordHasher.Hash(registerDto.Password),
            Role = role
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return "User created successfully";
    }

    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

        if (user == null || !_passwordHasher.Verify(loginDto.Password, user.Password))
            throw new Exception("Invalid email or password");

        var jwtKey = _configuration["Jwt:Key"] ?? throw new Exception("No JWT key found");
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("Name", user.Name),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
