using System;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
    }
}

class Program
{
    // Linear Search
    static Product LinearSearch(Product[] products, string name)
    {
        foreach (var p in products)
        {
            if (p.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase))
                return p;
        }
        return null;
    }

    // Binary Search (Assume sorted by ProductName)
    static Product BinarySearch(Product[] products, string name)
    {
        int left = 0, right = products.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            int cmp = string.Compare(products[mid].ProductName, name, StringComparison.OrdinalIgnoreCase);

            if (cmp == 0) return products[mid];
            else if (cmp < 0) left = mid + 1;
            else right = mid - 1;
        }
        return null;
    }

    static void Main(string[] args)
    {
        Product[] products = {
            new Product(101, "Camera", "Electronics"),
            new Product(102, "Laptop", "Electronics"),
            new Product(103, "Shoes", "Fashion"),
            new Product(104, "Watch", "Fashion"),
            new Product(105, "Phone", "Electronics")
        };

        // Sort by ProductName for Binary Search
        Array.Sort(products, (a, b) => a.ProductName.CompareTo(b.ProductName));

        Console.WriteLine("Search: Laptop");

        // Linear Search
        var result1 = LinearSearch(products, "Laptop");
        Console.WriteLine(result1 != null ? "[Linear] Found: " + result1 : "[Linear] Product not found");

        // Binary Search
        var result2 = BinarySearch(products, "Laptop");
        Console.WriteLine(result2 != null ? "[Binary] Found: " + result2 : "[Binary] Product not found");
    }
}
