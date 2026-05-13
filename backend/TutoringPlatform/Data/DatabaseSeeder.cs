using Microsoft.EntityFrameworkCore;
using TutoringPlatform.Models;
using TutoringPlatform.Services;

namespace TutoringPlatform.Data;

public class DatabaseSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

        await context.Database.MigrateAsync();

        if (await context.Users.AnyAsync())
        {
            return;
        }

        var testUsers = new List<User>
        {
            new User
            {
                Email = "will@gmail.com",
                Name = "Will Smith",
                Password = passwordHasher.Hash("12345678"),
                Role = UserRole.Student
            },

            new User
            {
                Email = "JohnPork@gmail.com",
                Name = "John Pork",
                Password = passwordHasher.Hash("ZAQ!2wsx"),
                Role = UserRole.Student
            },

            new User
            {
                Email = "edekZgredek@wp.pl",
                Name = "Edzio",
                Password = passwordHasher.Hash("nONWID#(*7gg7f"),
                Role = UserRole.Student
            },

            new User
            {
                Email = "Carlito@gmail.com",
                Name = "Carl Johnson",
                Password = passwordHasher.Hash("99v3bvb8"),
                Role = UserRole.Tutor
            },

            new User
            {
                Email = "Paker@op.pl",
                Name = "Paty Kerry",
                Password = passwordHasher.Hash("12345678"),
                Role = UserRole.Tutor
            },

            new User
            {
                Email = "chandler@gmail.com",
                Name = "Chandler Bing",
                Password = passwordHasher.Hash("transponster123"),
                Role = UserRole.Student
            },
            new User
            {
                Email = "joey@gmail.com",
                Name = "Joey Tribbiani",
                Password = passwordHasher.Hash("pizzaLover99"),
                Role = UserRole.Student
            },
            new User
            {
                Email = "Carlito@gmail.com",
                Name = "Carl Johnson",
                Password = passwordHasher.Hash("99v3bvb8"),
                Role = UserRole.Tutor,
                TutoringAds = new List<TutoringAd>
                {
                    new TutoringAd
                    {
                        Title = "Matematyka - Matura rozszerzona",
                        Description = "Przygotowanie do matury z matematyki na poziomie rozszerzonym.Jestem doświadczonym korepetytorem matematyki i skutecznie przygotowuję uczniów do matury rozszerzonej. Na zajęciach skupiamy się na pełnym zrozumieniu wymagań CKE oraz na nauce pisania rozwiązań ściśle pod klucz egzaminacyjny. Krok po kroku opanujemy najtrudniejsze zagadnienia, takie jak dowody matematyczne, zadania z parametrem oraz analizę matematyczną. Wyjaśniam skomplikowane schematy w prosty, logiczny sposób i uczę praktycznych strategii rozwiązywania arkuszy. Każdy uczeń otrzymuje ode mnie kompletne materiały dydaktyczne, autorskie zadania oraz pełne wsparcie na komunikatorze także między lekcjami. Pomagam przełamać stres przed egzaminem, systematycznie buduję pewność siebie i wspieram w walce o wynik powyżej 80 procent. Regularnie weryfikuję postępy za pomocą próbnych matur, aby precyzyjnie wyeliminować wszelkie braki wiedzy. Zajęcia prowadzę w bezstresowej, pełnej zaangażowania atmosferze, która motywuje do systematycznej pracy i myślenia analitycznego." ,
                        Price = 80,
                        IsOnline = true,
                        IsAvailable = true,
                        TutorId = 0
                    },
                    new TutoringAd
                    {
                        Title = "Fizyka dla studentów",
                        Description = "Mechanika klasyczna i elektrodynamika dla kierunków inżynierskich.",
                        Price = 100,
                        IsOnline = false,
                        IsAvailable = true,
                        TutorId = 0
                    }
                }
            },
            new User
            {
                Email = "Paker@op.pl",
                Name = "Paty Kerry",
                Password = passwordHasher.Hash("12345678"),
                Role = UserRole.Tutor,
                TutoringAds = new List<TutoringAd>
                {
                    new TutoringAd
                    {
                        Title = "Angielski - konwersacje",
                        Description = "Przełam barierę językową z native speakerem.",
                        Price = 70,
                        IsOnline = true,
                        IsAvailable = true,
                        TutorId = 0
                    },
                    new TutoringAd
                    {
                        Title = "Angielski Business",
                        Description = "Słownictwo biznesowe i techniczne.",
                        Price = 120,
                        IsOnline = true,
                        IsAvailable = true,
                        TutorId = 0
                    }
                }
            },
            new User
            {
                Email = "monica@gmail.com",
                Name = "Monica Geller",
                Password = passwordHasher.Hash("cleanfreak1"),
                Role = UserRole.Tutor,
                TutoringAds = new List<TutoringAd>
                {
                    new TutoringAd
                    {
                        Title = "Gotowanie i organizacja",
                        Description = "Profesjonalne warsztaty kulinarno-organizacyjne.",
                        Price = 150,
                        IsOnline = false,
                        IsAvailable = true,
                        TutorId = 0
                    },
                    new TutoringAd
                    {
                        Title = "Chemia - szkoła średnia",
                        Description = "Powtórki do sprawdzianów i matury podstawowej.",
                        Price = 60,
                        IsOnline = true,
                        IsAvailable = true,
                        TutorId = 0
                    }
                }
            },
            new User
            {
                Email = "ross@gmail.com",
                Name = "Ross Geller",
                Password = passwordHasher.Hash("dinosaursRock"),
                Role = UserRole.Tutor,
                TutoringAds = new List<TutoringAd>
                {
                    new TutoringAd
                    {
                        Title = "Paleontologia dla pasjonatów",
                        Description = "Wykłady o dinozaurach i ewolucji.",
                        Price = 90,
                        IsOnline = true,
                        IsAvailable = true,
                        TutorId = 0
                    },
                    new TutoringAd
                    {
                        Title = "Biologia - poziom maturalny",
                        Description = "Zrozumienie procesów komórkowych i genetyki.",
                        Price = 75,
                        IsOnline = true,
                        IsAvailable = true,
                        TutorId = 0
                    }
                }
            },
            new User
            {
                Email = "rachel@gmail.com",
                Name = "Rachel Green",
                Password = passwordHasher.Hash("fashionIcon2026"),
                Role = UserRole.Tutor,
                TutoringAds = new List<TutoringAd>
                {
                    new TutoringAd
                    {
                        Title = "Marketing i Moda",
                        Description = "Podstawy marketingu w branży fashion.",
                        Price = 110,
                        IsOnline = true,
                        IsAvailable = true,
                        TutorId = 0
                    },
                    new TutoringAd
                    {
                        Title = "Język francuski od zera",
                        Description = "Podstawowe zwroty i gramatyka dla początkujących.",
                        Price = 65,
                        IsOnline = true,
                        IsAvailable = true,
                        TutorId = 0
                    }
                }
            }
        };

        await context.Users.AddRangeAsync(testUsers);
        await context.SaveChangesAsync();
    }
}