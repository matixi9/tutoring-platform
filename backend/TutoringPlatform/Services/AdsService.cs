using Microsoft.EntityFrameworkCore;
using TutoringPlatform.Data;
using TutoringPlatform.DTOs;
using TutoringPlatform.Models;

namespace TutoringPlatform.Services;

public interface IAdsService
{
    Task<IEnumerable<TutoringAdDto>> GetAllAsync(string? searchPhrase, int? maxPrice, bool? isOnline);
    Task<TutoringAdDto?> GetByIdAsync(int id);
    Task<TutoringAdDto> CreateAsync(CreateTutoringAdDto dto, int tutorId);
    Task<bool> UpdateAsync(int id, UpdateTutoringAdDto dto, int tutorId);
    Task<bool> DeleteAsync(int id, int tutorId);
}

public class AdsService : IAdsService
{
    private readonly ApplicationDbContext _context;

    public AdsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TutoringAdDto>> GetAllAsync(string? searchPhrase, int? maxPrice, bool? isOnline)
    {
        var query = _context.TutoringAds
            .Include(t => t.Tutor)
            .Where(t => t.IsAvailable)
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchPhrase))
        {
            var lowerPhrase = searchPhrase.ToLower();
            query = query.Where(a =>
                a.Title.ToLower().Contains(lowerPhrase) ||
                a.Description.ToLower().Contains(lowerPhrase));
        }

        if (maxPrice.HasValue)
            query = query.Where(a => a.Price <= maxPrice.Value);

        if (isOnline.HasValue)
            query = query.Where(a => a.IsOnline == isOnline.Value);

        var ads = await query.ToListAsync();
        return ads.Select(a => new TutoringAdDto
        {
            Id = a.Id,
            Title = a.Title,
            Description = a.Description,
            Price = a.Price,
            IsOnline = a.IsOnline,
            IsAvailable = a.IsAvailable,
            TutorName = a.Tutor!.Name,
            TutorId = a.TutorId
        });
    }

    public async Task<TutoringAdDto?> GetByIdAsync(int id)
    {
        var ad = await _context.TutoringAds.Include(a => a.Tutor).FirstOrDefaultAsync(a => a.Id == id);
        if (ad == null)
        {
            return null;
        }

        return new TutoringAdDto
        {
            Id = ad.Id,
            Title = ad.Title,
            Description = ad.Description,
            Price = ad.Price,
            IsOnline = ad.IsOnline,
            IsAvailable = ad.IsAvailable,
            TutorName = ad.Tutor!.Name,
            TutorId = ad.TutorId
        };
    }

    public async Task<TutoringAdDto> CreateAsync(CreateTutoringAdDto dto, int tutorId)
    {
        var ad = new TutoringAd
        {
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price,
            IsOnline = dto.IsOnline,
            IsAvailable = dto.IsAvailable,
            TutorId = tutorId
        };

        await _context.TutoringAds.AddAsync(ad);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(ad.Id) ??
               throw new Exception("Wystąpił błąd podczas tworzenia ogłoszenia");
    }


    public async Task<bool> UpdateAsync(int id, UpdateTutoringAdDto dto, int tutorId)
    {
        var ad = await _context.TutoringAds.FirstOrDefaultAsync(a => a.Id == id);
        if (ad == null)
        {
            return false;
        }

        if (ad.TutorId != tutorId)
        {
            throw new Exception("Nie możesz edytować ogłoszenia które nie jest twoje ");
        }

        ad.Title = dto.Title;
        ad.Description = dto.Description;
        ad.Price = dto.Price;
        ad.IsOnline = dto.IsOnline;
        ad.IsAvailable = dto.IsAvailable;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id, int tutorId)
    {
        var ad = await _context.TutoringAds.FirstOrDefaultAsync(a => a.Id == id);

        if (ad == null)
        {
            return false;
        }

        if (ad.TutorId != tutorId)
        {
            throw new Exception("Nie możesz usunąć ogłoszenia które nie jest twoje");
        }

        _context.TutoringAds.Remove(ad);
        await _context.SaveChangesAsync();
        return true;
    }
}