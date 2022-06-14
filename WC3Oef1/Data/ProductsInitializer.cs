using System.Linq;
using WC3Oef1.Enums;
using WC3Oef1.Models;

namespace WC3Oef1.Data
{
    public class ProductsInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // check of databank bestaat, indien niet zal deze call het aanmaken
            context.Database.EnsureCreated();

            // check of er al Products in de db staan
            if (context.Products.Any()) {
                return; // er bestaan reeds Products, geen seeding nodig
            }

            // List<Product> werkt ook, maar array is performanter
            var Products = new Product[]
            {
                new Product { Name =  "PS5", Description = "PlayStation 5 + Sony PlayStation 5 DualSense draadloze controller. Aan een veel te hoge prijs, wegens overal uitverkocht.", Category = Category.Consoles, Price = 799.99M},
                new Product { Name =  "XBox", Description = "Xbox Series X", Category = Category.Consoles, Price = 499.99M},
                new Product { Name =  "Console: The Console", Description = "Supermegasnelle console met graphics en hardware en meer van dat lekkers", Category = Category.Consoles, Price = 9999.99M},
                new Product { Name =  "KFConsole", Description = "Forged from the fires of the KFC ovens, there has never been a tastier way to experience the latest titles in stunning 4k, 240fps.", Category = Category.Consoles, Price = 499.99M},
                new Product { Name =  "Game: The Game", Description = "Super leuk spelletje", Category = Category.Games, Price = 999.99M},
                new Product { Name =  "Arachnid Male: Miles Morales", Description = "Top 10 game of 2020", Category = Category.Games, Price = 44.44M},
                new Product { Name =  "Amidst us", Description = "Top 10 game of 2020", Category = Category.Games, Price = 55.55M},
                new Product { Name =  "Creature Intersection: Novel Purviews", Description = "Top 10 game of 2020", Category = Category.Games, Price = 33.33M},
                new Product { Name =  "Request of Assignment: Combat area", Description = "Top 10 game of 2020", Category = Category.Games, Price = 66.66M},
                new Product { Name =  "Blade Runner Whiskey Glasses", Description = "The perfect gift for booze-loving Blade Runner fans", Category = Category.Gadgets, Price = 138.99M},
                new Product { Name =  "PlayStation Alarm Clock", Description = "Alarm clock in the shape of a PS4 controller. Better then using your phone's alarm anyway...", Category = Category.Gadgets, Price = 28.99M},
                new Product { Name =  "Tetris Stackable Toy Light", Description = "Multicoloured novelty lamp featuring seven different Tetromino shapes which light up once they come into contact with each other.", Category = Category.Gadgets, Price = 37.98M},
                new Product { Name =  "Gaming head set", Description = "Look! Is it a headphone? Is it a microphone? Nope... it's BOTH!", Category = Category.Gear, Price = 149.99M},
                new Product { Name =  "HyperX Keyboard", Description = "The keys are made of solid tritanium. Featuring a completely useless \"calculator\" button.", Category = Category.Gear, Price = 83.99M},
                new Product { Name =  "PDMLV55 Wireless Mouse", Description = "Featuring over 254 detachable buttons, it will turn (you) into the ultimate gaming tool.", Category = Category.Gear, Price = 255.99M},
                new Product { Name =  "Aceus HAL PG051651XXQ Monitor", Description = "A 65K 44inch 360° 5D monitor with a resolution up to 51000p and a 840hz refresh rate.  Will make your games come to life... literally. VGA cable included.", Category = Category.Gear, Price = 9999.99M}
            };

            // Products toevoegen
            context.Products.AddRange(Products);

            // context wegschrijven naar db
            context.SaveChanges();
        }
    }
}
