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

            // Lab 6: Updating and Deleting Records
            var toUpdate = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
            if (toUpdate != null)
            {
                toUpdate.Price = 70000;
                await context.SaveChangesAsync();
                Console.WriteLine($"\nUpdated Laptop price to: {toUpdate.Price}");
            }

            var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
            if (toDelete != null)
            {
                context.Products.Remove(toDelete);
                await context.SaveChangesAsync();
                Console.WriteLine("Deleted: Rice Bag");
            }

            // Lab 7: Writing Queries with LINQ
            var filtered = await context.Products
                .Where(p => p.Price > 1000)
                .OrderByDescending(p => p.Price)
                .ToListAsync();
            Console.WriteLine("\nFiltered & Sorted Products:");
            foreach (var p in filtered)
                Console.WriteLine($"{p.Name} - {p.Price}");

            var productDTOs = await context.Products
                .Select(p => new { p.Name, p.Price })
                .ToListAsync();
            Console.WriteLine("\nProduct DTOs:");
            foreach (var p in productDTOs)
                Console.WriteLine($"{p.Name} - {p.Price}");
        }
    }
}
