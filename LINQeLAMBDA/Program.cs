using System;
using System.Collections.Generic;
using System.Linq;
using LINQeLAMBDA.Entities;

namespace LINQeLAMBDA
{
    class Program
    {
        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Electronics", Tier = 1 };

            List<Product> products = new List<Product>()
            {
                new Product(){ Id = 1, Name = "Computer", Price = 1100.0, Category = c2},
                new Product(){ Id = 2, Name = "Hammer", Price = 90.0, Category = c1},
                new Product(){ Id = 3, Name = "TV", Price = 1700.0, Category = c3},
                new Product(){ Id = 4, Name = "Notebook", Price = 1300.0, Category = c2},
                new Product(){ Id = 5, Name = "Saw", Price = 80.0, Category = c1},
                new Product(){ Id = 6, Name = "Tablet", Price = 700.0, Category = c2},
                new Product(){ Id = 7, Name = "Camera", Price = 700.0, Category = c3},
                new Product(){ Id = 8, Name = "Printer", Price = 350.0, Category = c3},
                new Product(){ Id = 9, Name = "MacBook", Price = 1800.0, Category = c2},
                new Product(){ Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3},
                new Product(){ Id = 11, Name = "Level", Price = 70.0, Category = c1}
            };
            IEnumerable<Product> r1 = products.Where(x => x.Price < 900.0 && x.Category.Tier == 1);

            Print("TIER 1 AND PRICE < 900.0", r1);

            Console.WriteLine("--------------------------------");

            IEnumerable<string> r2 = products.Where(x => x.Category.Name == "Tools").Select(p => p.Name);

            Print("NAMES OF PRODUCTS FROM TOOLS", r2);

            var r3 = products.Where(x => x.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });

            Print("NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT", r3);

            IEnumerable<Product> r4 = products.Where(x => x.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);

            Print("TIER 1 ORDER BY PRICE THAN BY NAME", r4);

            IEnumerable<Product> r5 = r4.Skip(2).Take(4);

            Print("TIER 1 ORDER BY PRICE THAN BY NAME AND SKIP 2 TAKE 4", r5);

            // Tendo certeza que o resultado e só um valor, pode-se usar o final .First() .FirstOrDefault() e por ai vai
            Product r6 = products.FirstOrDefault();

            Console.WriteLine("First or Default test1: " + r6);

            Product r7 = products.Where(p => p.Price > 3000.0).FirstOrDefault();

            Console.WriteLine("First or Default test2: " + r7);

            Product r8 = products.Where(p => p.Id == 3).SingleOrDefault();

            Console.WriteLine("Single or Default test1: " + r8);

            Product r9 = products.Where(p => p.Id == 30).SingleOrDefault();

            Console.WriteLine("Single or Default test2: " + r9);



        }
    }
}
