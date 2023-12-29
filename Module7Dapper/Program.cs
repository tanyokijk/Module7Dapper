using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;
using Microsoft.EntityFrameworkCore;
using Module7Dapper.DataContext;
using Dapper;
using Module7Dapper.Models;
using System.Threading;
using System.Linq.Expressions;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        using (DataContext dc = new DataContext())
        {
            Category cat1 = new Category { Name = "Ноутбуки" };
            Category cat2 = new Category { Name = "Планшети" };
            Category cat3 = new Category { Name = "Мишки" };
            Category cat4 = new Category { Name = "Клавіатури" };
            Category cat5 = new Category { Name = "Монітори" };

            User user1 = new User { Name = "Джуль Еміль Семенович", BirthDate = new DateTime(2000, 12, 01), Gender = User.GenderItem.Чоловік, Email = "nelavikautreu-7901@yopmail.com", Country = "Німеччина", City = "Берлін", Categories = { cat1, cat2 } };
            User user2 = new User { Name = "Керницька Владилена Левівна", BirthDate = new DateTime(2002, 11, 11), Gender = User.GenderItem.Жінка, Email = "matoh91248@wenkuu.com", Country = "Японія", City = "Токіо", Categories = { cat3, cat4 } };
            User user3 = new User { Name = "Усаченко Берта Устимівна", BirthDate = new DateTime(1980, 11, 21), Gender = User.GenderItem.Жінка, Email = "matoh91248@wenkuu.com", Country = "Польша", City = "Краків", Categories = { cat1 } };
            User user4 = new User { Name = "Іванов Іван Іванович", BirthDate = new DateTime(1990, 10, 26), Gender = User.GenderItem.Чоловік, Email = "ivanov@example.com", Country = "США", City = "Нью-Йорк", Categories = { cat1, cat5 } };
            User user5 = new User { Name = "Петренко Анна Володимирівна", BirthDate = new DateTime(1980, 11, 21), Gender = User.GenderItem.Жінка, Email = "anna@example.com", Country = "Франція", City = "Париж", Categories = { cat4, cat2 } };
            User user6 = new User { Name = "Сидоренко Олександр Петрович", BirthDate = new DateTime(1995, 7, 8), Gender = User.GenderItem.Чоловік, Email = "oleksandr@example.com", Country = "Україна", City = "Харків", Categories = { cat3, cat2, cat5 } };
            User user7 = new User { Name = "Петренко Андрій Іванович", BirthDate = new DateTime(2002, 8, 8), Gender = User.GenderItem.Чоловік, Email = "andriy@example.com", Country = "Південна Корея", City = "Сеул", Categories = { cat5 } };
            User user8 = new User { Name = "Ковальов Іван Олександрович", BirthDate = new DateTime(2002, 8, 8), Gender = User.GenderItem.Чоловік, Email = "volodymyr@example.com", Country = "Україна", City = "Київ", Categories = { cat4, cat5 } };
            User user9 = new User { Name = "Ковальчук Тетяна Ігорівна", BirthDate = new DateTime(2003, 3, 18), Gender = User.GenderItem.Жінка, Email = "oksana@example.com", Country = "Польша", City = "Варшава", Categories = { cat4, cat1 } };
            User user10 = new User { Name = "Сидоренко Артем Олександрович", BirthDate = new DateTime(1999, 9, 9), Gender = User.GenderItem.Чоловік, Email = "artem@example.com", Country = "Україна", City = "Львів", Categories = { cat1, cat2, cat3 } };
            User user11 = new User { Name = "Ткаченко Єлизавета Сергіївна", BirthDate = new DateTime(1998, 7, 3), Gender = User.GenderItem.Жінка, Email = "yelyzaveta@example.com", Country = "Німеччина", City = "Мюнхен", Categories = { cat4, cat5 } };
            User user12 = new User { Name = "Морозов Анатолій Ігорович", BirthDate = new DateTime(2001, 5, 25), Gender = User.GenderItem.Чоловік, Email = "anatoliy@example.com", Country = "США", City = "Чикаго", Categories = { cat1, cat4 } };

            Good laptop1 = new Good { Name = "Ноутбук HP Pavilion 15" };
            Good laptop2 = new Good { Name = "Ноутбук Dell XPS 13" };
            Good laptop3 = new Good { Name = "Ноутбук Lenovo ThinkPad X1 Carbon" };
            Good laptop4 = new Good { Name = "Ноутбук MacBook Air" };

            Good tablet1 = new Good { Name = "Планшет Apple iPad Pro" };
            Good tablet2 = new Good { Name = "Планшет Samsung Galaxy Tab S7" };
            Good tablet3 = new Good { Name = "Планшет Microsoft Surface Pro 7" };
            Good tablet4 = new Good { Name = "Планшет Huawei MatePad Pro" };

            Good mouse1 = new Good { Name = "Миша Logitech G102 Lightsync USB White (910-005824)" };
            Good mouse2 = new Good { Name = "Миша Razer DeathAdder V2 Pro" };
            Good mouse3 = new Good { Name = "Миша Microsoft Surface Precision Mouse" };
            Good mouse4 = new Good { Name = "Миша Corsair Dark Core RGB Pro" };

            Good monitor1 = new Good { Name = "Монітор ASUS ROG Swift PG259QN" };
            Good monitor2 = new Good { Name = "Монітор LG UltraGear 27GN950-B" };
            Good monitor3 = new Good { Name = "Монітор Dell UltraSharp U2720Q" };
            Good monitor4 = new Good { Name = "Монітор Samsung Odyssey G7" };

            Good keyboard1 = new Good { Name = "Клавіатура Corsair K70 RGB MK.2" };
            Good keyboard2 = new Good { Name = "Клавіатура Logitech G Pro X" };
            Good keyboard3 = new Good { Name = "Клавіатура Razer BlackWidow V3" };
            Good keyboard4 = new Good { Name = "Клавіатура SteelSeries Apex Pro" };

            Promotion pr1 = new Promotion { Country = "США", StartDate = new DateTime(2023,12,12), EndDate = new DateTime(2023, 12,22), PromotionsCategory = cat1, Goods = { laptop1, laptop2, laptop3, laptop4 } };
            Promotion pr2 = new Promotion { Country = "Польша", StartDate = new DateTime(2023, 12, 12), EndDate = new DateTime(2023, 12, 22), PromotionsCategory = cat1, Goods = { laptop1, laptop4 } };
            Promotion pr3 = new Promotion { Country = "Німеччина", StartDate = new DateTime(2023, 12, 12), EndDate = new DateTime(2023, 12, 22), PromotionsCategory = cat1, Goods = { laptop1, laptop2 } };
            Promotion pr4 = new Promotion { Country = "Японія", StartDate = new DateTime(2023, 12, 12), EndDate = new DateTime(2023, 12, 22), PromotionsCategory = cat2, Goods = { tablet1, tablet2, tablet3, tablet4 } };
            Promotion pr5 = new Promotion { Country = "Україна", StartDate = new DateTime(2023, 12, 12), EndDate = new DateTime(2023, 12, 22), PromotionsCategory = cat2, Goods = { tablet1, tablet2 } };
            Promotion pr6 = new Promotion { Country = "Південна Корея", StartDate = new DateTime(2023, 11, 30), EndDate = new DateTime(2023, 12, 10), PromotionsCategory = cat3, Goods = { mouse1, mouse2, mouse3, mouse4 } };
            Promotion pr7 = new Promotion { Country = "Польша", StartDate = new DateTime(2023, 11, 30), EndDate = new DateTime(2023, 12, 10), PromotionsCategory = cat4, Goods = { keyboard1, keyboard2, keyboard3, keyboard4 } };
            Promotion pr8 = new Promotion { Country = "Німеччина", StartDate = new DateTime(2023, 11, 30), EndDate = new DateTime(2023, 12, 10), PromotionsCategory = cat5, Goods = { monitor1, monitor4 } };
            Promotion pr9 = new Promotion { Country = "Японія", StartDate = new DateTime(2023, 10, 12), EndDate = new DateTime(2023, 11, 7), PromotionsCategory = cat3, Goods = { mouse2, mouse3, mouse4 } };
            Promotion pr10 = new Promotion { Country = "Україна", StartDate = new DateTime(2023, 12, 12), EndDate = new DateTime(2023, 12, 22), PromotionsCategory = cat4, Goods = { keyboard1, keyboard2, keyboard4 } };
            Promotion pr11 = new Promotion { Country = "США", StartDate = new DateTime(2023, 12, 12), EndDate = new DateTime(2023, 12, 22), PromotionsCategory = cat1, Goods = { laptop1, laptop3, laptop4 } };
            Promotion pr12 = new Promotion { Country = "Польша", StartDate = new DateTime(2023, 12, 12), EndDate = new DateTime(2023, 12, 22), PromotionsCategory = cat1, Goods = { laptop2 } };
            Promotion pr13 = new Promotion { Country = "Німеччина", StartDate = new DateTime(2023, 12, 12), EndDate = new DateTime(2023, 12, 22), PromotionsCategory = cat3, Goods = { mouse1 } };
            Promotion pr14 = new Promotion { Country = "Японія", StartDate = new DateTime(2023, 12, 12), EndDate = new DateTime(2023, 12, 22), PromotionsCategory = cat5, Goods = { monitor1, monitor3, monitor4 } };
            Promotion pr15 = new Promotion { Country = "Україна", StartDate = new DateTime(2023, 12, 12), EndDate = new DateTime(2023, 12, 22), PromotionsCategory = cat4, Goods = { keyboard4 } };
            Promotion pr16 = new Promotion { Country = "Південна Корея", StartDate = new DateTime(2023, 11, 30), EndDate = new DateTime(2023, 12, 10), PromotionsCategory = cat3, Goods = { mouse3, mouse4 } };
            Promotion pr17 = new Promotion { Country = "Польша", StartDate = new DateTime(2023, 11, 30), EndDate = new DateTime(2023, 12, 10), PromotionsCategory = cat2, Goods = { tablet1, tablet3, tablet4 } };
            Promotion pr18 = new Promotion { Country = "Німеччина", StartDate = new DateTime(2023, 11, 30), EndDate = new DateTime(2023, 12, 10), PromotionsCategory = cat5, Goods = { monitor1, monitor2, monitor3, monitor4 } };
            Promotion pr19 = new Promotion { Country = "Японія", StartDate = new DateTime(2023, 10, 9), EndDate = new DateTime(2023, 11, 10), PromotionsCategory = cat3, Goods = { mouse1, mouse3 } };
            Promotion pr20 = new Promotion { Country = "Україна", StartDate = new DateTime(2023, 11, 10), EndDate = new DateTime(2023, 11, 22), PromotionsCategory = cat4, Goods = { keyboard3, keyboard4 } };

            dc.Categories.AddRange(cat1, cat2, cat3, cat4);
            dc.Users.AddRange(user1, user2, user3, user4, user5, user6, user7, user8, user9, user10, user11, user12);
            dc.Goods.AddRange(laptop1, laptop2, laptop3, laptop4, mouse1, mouse2, mouse3, mouse4, keyboard1, keyboard2, keyboard3, keyboard4, monitor1, monitor2, monitor3, monitor4);
            dc.Promotions.AddRange(pr1, pr2, pr3, pr4, pr5, pr6, pr7, pr8, pr9, pr10, pr11, pr12, pr13, pr14, pr15, pr16, pr17, pr18, pr19, pr20);

            dc.SaveChanges();

            using (var connection = dc.Database.GetDbConnection())
            {
                connection.Open();

                var users = connection.Query<User>("SELECT * FROM Users").ToList();
                Console.WriteLine("Всі користувачі: ");
                Console.WriteLine();
                Console.WriteLine("{0,-30} {1,-15} {2,-10} {3,-30} {4,-15} {5,-15}", "ПІБ", "Дата народження", "Гендер", "E-mail", "Країна", "Місто");
                foreach (var item in users)
                {
                    Console.WriteLine("{0,-30} {1,-15} {2,-10} {3,-30} {4,-15} {5,-15}", item.Name, item.BirthDate.ToShortDateString(), item.Gender, item.Email, item.Country, item.City);
                }

                Console.ReadKey();
                Console.Clear();

                var usersemail = connection.Query<string>("SELECT Email FROM Users").ToList();
                Console.WriteLine("E-mail всіх користувачів: ");
                Console.WriteLine();
                foreach (var item in usersemail)
                {
                    Console.WriteLine(item);
                }

                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("Всі категорії: ");
                Console.WriteLine();
                var categories = connection.Query<string>("SELECT Name FROM Categories").ToList();
                foreach (var item in categories)
                {
                    Console.WriteLine(item);
                }

                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("Всі акційні товари: ");
                Console.WriteLine();
                var goods = connection.Query<string>("SELECT Name FROM Goods").ToList();
                foreach (var item in goods)
                {
                    Console.WriteLine(item);
                }

                Console.ReadKey();
                Console.Clear();

                var userscities = connection.Query<string>("SELECT City FROM Users").ToList();
                Console.WriteLine("Усі міста: ");
                Console.WriteLine();
                foreach (var item in userscities)
                {
                    Console.WriteLine(item);
                }

                Console.ReadKey();
                Console.Clear();

                var userscountries = connection.Query<string>("SELECT Country FROM Users").ToList();
                Console.WriteLine("Усі країни: ");
                Console.WriteLine();
                foreach (var item in userscountries)
                {
                    Console.WriteLine(item);
                }

                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("Пошук користувачів за містом");
                Console.WriteLine("Введіть назву міста:");
                var city = Console.ReadLine();
                var usersrfomcity = connection.Query<string>("SELECT Name FROM Users WHERE City=@City", new { City = city }).ToList();
                Console.WriteLine("Користувачі: ");
                Console.WriteLine();
                foreach (var item in usersrfomcity)
                {
                    Console.WriteLine(item);
                }

                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("Пошук користувачів за країною");
                Console.WriteLine("Введіть назву країни:");
                var country = Console.ReadLine();
                var usersrfomcountry = connection.Query<string>("SELECT Name FROM Users WHERE Country=@Country", new { Country = country }).ToList();
                Console.WriteLine("Користувачі: ");
                Console.WriteLine();
                foreach (var item in usersrfomcountry)
                {
                    Console.WriteLine(item);
                }

                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("Пошук акцій за країною");
                Console.WriteLine("Введіть назву країни:");
                country = Console.ReadLine();
                var promotions = connection.Query<Promotion, Good, Promotion>(
                @"SELECT * FROM Promotions
              JOIN Goods ON Promotions.Id = Goods.PromotionId
              WHERE Promotions.Country = @Country",
                (promotion, promotedItem) =>
                {
                    promotion.Goods.Add(promotedItem);
                    return promotion;
                },
                new { Country = country },
                splitOn: "Id"
            ).Distinct().ToList();


                foreach (var item in promotions)
                {
                    Console.WriteLine($"\nКраїна: {item.Country}, дата початку: {item.StartDate}, дата кінця: {item.EndDate}");
                    Console.WriteLine("Товар:");
                    foreach (var good in item.Goods)
                    {
                        Console.WriteLine($" - ID товару: {good.Id}, назва: {good.Name}");
                    }
                }
            }
        }
    }
}