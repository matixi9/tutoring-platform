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
                        Description =
                            "Przygotowanie do matury z matematyki na poziomie rozszerzonym to proces wymagający czasu, cierpliwości i odpowiedniej strategii. " +
                            "Moje zajęcia to kompleksowy program nauczania, który krok po kroku przeprowadzi Cię przez wszystkie działy wymagane na egzaminie dojrzałości, " +
                            "od algebry i analizy matematycznej, aż po geometrię przestrzenną i rachunek prawdopodobieństwa. " +
                            "Podczas lekcji kładę ogromny nacisk nie tylko na bezbłędne rozwiązywanie równań, ale przede wszystkim na logiczne myślenie i zrozumienie mechanizmów stojących za konkretnymi wzorami. " +
                            "Udostępniam autorskie materiały dydaktyczne, setki zadań z ubiegłych lat oraz próbne arkusze maturalne. " +
                            "Zapewniam indywidualne podejście do każdego ucznia, pomagając przełamać strach przed matematyką i wypracować pewność siebie niezbędną do osiągnięcia wyniku powyżej 80%, " +
                            "co otworzy Ci drzwi na wymarzone studia inżynierskie lub informatyczne.",
                        Price = 80,
                        IsOnline = true,
                        IsAvailable = true,
                        TutorId = 0
                    },
                    new TutoringAd
                    {
                        Title = "Fizyka dla studentów",
                        Description = "Mechanika klasyczna i elektrodynamika dla kierunków inżynierskich. " +
                                      "Skupiamy się na rozwiązywaniu złożonych układów równań i praktycznym zastosowaniu praw fizyki.",
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
                        Description = "Przełam barierę językową z native speakerem. " +
                                      "Rozmowy na tematy codzienne, podróżnicze i kulturowe z korektą wymowy i akcentu na bieżąco.",
                        Price = 70,
                        IsOnline = true,
                        IsAvailable = true,
                        TutorId = 0
                    },
                    new TutoringAd
                    {
                        Title = "Angielski Business",
                        Description = "Słownictwo biznesowe i techniczne. " +
                                      "Uczymy się pisania formalnych maili, przygotowywania prezentacji oraz prowadzenia negocjacji w międzynarodowym środowisku.",
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
                        Description =
                            "Profesjonalne warsztaty kulinarno-organizacyjne skierowane do osób, które chcą zrewolucjonizować swoje codzienne gotowanie i zarządzanie domową kuchnią. " +
                            "Gotowanie to nie tylko sztuka łączenia smaków, ale przede wszystkim doskonała organizacja czasu, przestrzeni oraz budżetu. " +
                            "Na moich zajęciach nauczysz się, jak planować posiłki na cały tydzień, jak mądrze robić zakupy, aby unikać marnowania żywności, oraz jak wyposażyć swoją kuchnię w absolutnie niezbędne sprzęty. " +
                            "Krok po kroku przygotujemy wspólnie pełnowartościowe i zbilansowane potrawy, od klasycznych obiadów po wykwintne kolacje dla gości, ucząc się przy tym podstawowych technik kulinarnych " +
                            "takich jak prawidłowe krojenie, blanszowanie, smażenie w odpowiednich temperaturach czy redukcja sosów. " +
                            "Niezależnie od tego, czy jesteś absolutnym nowicjuszem, któremu przypala się woda na herbatę, czy kulinarnym entuzjastą pragnącym uporządkować swoją wiedzę, " +
                            "te zajęcia całkowicie odmienią Twoje podejście do przyrządzania posiłków.",
                        Price = 150,
                        IsOnline = false,
                        IsAvailable = true,
                        TutorId = 0
                    },
                    new TutoringAd
                    {
                        Title = "Chemia - szkoła średnia",
                        Description = "Powtórki do sprawdzianów i matury podstawowej. " +
                                      "Przerabiamy stechiometrię, kwasy, zasady oraz podstawy chemii organicznej.",
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
                        Description =
                            "Wykłady o dinozaurach i ewolucji to pasjonująca podróż w czasie o setki milionów lat wstecz, aż do epoki, kiedy na naszej planecie niepodzielnie królowały gigantyczne gady. " +
                            "Kurs ten jest dedykowany nie tylko studentom nauk biologicznych, ale każdemu pasjonatowi historii Ziemi, który pragnie zgłębić tajemnice dawno wymarłych ekosystemów. " +
                            "Przeanalizujemy szczegółowo erę mezozoiczną, od triasu aż po dramatyczne wymieranie kredowe. " +
                            "Opowiem o niesamowitych adaptacjach ewolucyjnych, ewolucji lotu u pterozaurów oraz anatomii największych lądowych drapieżników w dziejach, takich jak Tyrannosaurus rex. " +
                            "Zaprezentuję metody pracy współczesnych paleontologów – od wykopalisk w trudnym terenie, przez datowanie izotopowe, po skomplikowane rekonstrukcje cyfrowe w środowiskach 3D. " +
                            "Dowiesz się także, dlaczego współczesne ptaki są bezpośrednimi potomkami teropodów i jak te niesamowite stworzenia przetrwały do dziś.",
                        Price = 90,
                        IsOnline = true,
                        IsAvailable = true,
                        TutorId = 0
                    },
                    new TutoringAd
                    {
                        Title = "Biologia - poziom maturalny",
                        Description = "Zrozumienie procesów komórkowych i genetyki. " +
                                      "Solidne przygotowanie do nowej matury z biologii z użyciem autorskich arkuszy.",
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
                        Description = "Podstawy marketingu w branży fashion. " +
                                      "Jak budować markę osobistą, analizować trendy sezonowe i docierać do grupy docelowej.",
                        Price = 110,
                        IsOnline = true,
                        IsAvailable = true,
                        TutorId = 0
                    },
                    new TutoringAd
                    {
                        Title = "Język francuski od zera",
                        Description = "Podstawowe zwroty i gramatyka dla początkujących. " +
                                      "Skupiamy się na praktycznej komunikacji i poprawnej paryskiej wymowie.",
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