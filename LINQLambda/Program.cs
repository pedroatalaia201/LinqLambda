using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace LINQLambda
{
    class Program
    {
        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);

            foreach(T obj in collection)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Eletronics", Tier = 1 };

            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = c2},
                new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1},
                new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = c3},
                new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2},
                new Product(){ Id = 5, Name = "Saw", Price = 80.0, Category = c1},
                new Product(){ Id = 6, Name = "Tablet", Price = 700.0, Category = c3},
                new Product(){ Id = 7, Name = "Camera", Price = 700.0, Category = c3},
                new Product(){ Id = 8, Name = "Printer", Price = 350.0, Category = c3},
                new Product(){ Id = 9, Name = "MacBook", Price = 1800.0, Category = c2 },
                new Product(){ Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3},
                new Product(){ Id=11, Name = "Level", Price = 70.0, Category = c1}
            };

            var result1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.00);
            Print("Tier 1 and Price < 900", result1);

            var result2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            Print("Names of products from tools", result2);

            var result3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            Print("Names started with 'C' and ANONYMOUS OBJETC", result3);

            var result4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            Print("Tier 1 order by price then by name", result4);

            //Pagination
            var result5 = result4.Skip(2).Take(4);
            Print("Tier 1 order by price the by name skip 2 take 4", result5);

            var result6 = products.First();
            Console.WriteLine("First test1: " + result6);

            // In case that the result does not match, use the default value(null)
            var result7 = products.Where(p => p.Price > 3000.0).FirstOrDefault();
            Console.WriteLine("First or Default test2:" + result7);

            var result8 = products.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine("Single or Default test1:" + result8);

            //null
            var result9 = products.Where(p => p.Id == 30).SingleOrDefault();
            Console.WriteLine("Single o Deafult test2: " + result9);
        } 
    }
}
