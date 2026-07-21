using System;
using System.Collections.Generic;

namespace EcommerceSearch
{
    public class Product : IComparable<Product>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return ProductId.CompareTo(other.ProductId);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                new Product { ProductId = 1, ProductName = "Laptop", Category = "Electronics" },
                new Product { ProductId = 2, ProductName = "Smartphone", Category = "Electronics" },
                new Product { ProductId = 3, ProductName = "Desk", Category = "Furniture" },
                new Product { ProductId = 4, ProductName = "Chair", Category = "Furniture" },
                new Product { ProductId = 5, ProductName = "Headphones", Category = "Electronics" }
            };

            // Linear Search
            Product? foundLinear = LinearSearch(products, 3);
            Console.WriteLine(foundLinear != null ? $"Linear Search: Found {foundLinear.ProductName}" : "Linear Search: Not Found");

            // Sort before Binary Search
            Array.Sort(products);

            // Binary Search
            Product? foundBinary = BinarySearch(products, 5);
            Console.WriteLine(foundBinary != null ? $"Binary Search: Found {foundBinary.ProductName}" : "Binary Search: Not Found");
        }

        public static Product? LinearSearch(Product[] products, int targetId)
        {
            foreach (var product in products)
            {
                if (product.ProductId == targetId)
                {
                    return product;
                }
            }
            return null;
        }

        public static Product? BinarySearch(Product[] products, int targetId)
        {
            int left = 0;
            int right = products.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (products[mid].ProductId == targetId)
                {
                    return products[mid];
                }
                else if (products[mid].ProductId < targetId)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return null;
        }
    }
}
