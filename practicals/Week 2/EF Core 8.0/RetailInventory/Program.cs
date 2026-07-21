using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RetailInventory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Retail Inventory System Initialized.");

            using var context = new AppDbContext();
            
            // Ensure Database is created
            await context.Database.EnsureCreatedAsync();

            // Lab 4: Inserting Initial Data
            if (!context.Categories.Any())
            {
                var electronics = new Category { Name = "Electronics" };
                var groceries = new Category { Name = "Groceries" };
                
                await context.Categories.AddRangeAsync(electronics, groceries);
                
                var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
                var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };
                
                await context.Products.AddRangeAsync(product1, product2);
                await context.SaveChangesAsync();
                Console.WriteLine("Data Inserted Successfully.");
            }

            // Lab 5: Retrieving Data
            // Retrieve All Products
            var products = await context.Products.ToListAsync();
            Console.WriteLine("\nAll Products:");
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} - {p.Price}");
            }

            // Find by ID
            var productById = await context.Products.FindAsync(1);
            Console.WriteLine($"\nFound by ID (1): {productById?.Name}");

            // FirstOrDefault with Condition
            var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
            Console.WriteLine($"\nExpensive: {expensive?.Name}");
        }
    }
}
