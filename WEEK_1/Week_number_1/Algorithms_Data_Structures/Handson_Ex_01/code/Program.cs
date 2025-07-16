using System;
using System.Collections.Generic;

// Product Model
public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public Product(int id, string name, int qty, double price)
    {
        ProductId = id;
        ProductName = name;
        Quantity = qty;
        Price = price;
    }

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {ProductName}, Qty: {Quantity}, Price: ₹{Price}";
    }
}

// Inventory System
public class InventorySystem
{
    private Dictionary<int, Product> inventory = new Dictionary<int, Product>();

    // Add product
    public void AddProduct(Product product)
    {
        if (!inventory.ContainsKey(product.ProductId))
        {
            inventory[product.ProductId] = product;
            Console.WriteLine("Product added.");
        }
        else
        {
            Console.WriteLine("Product ID already exists.");
        }
    }

    // Update product
    public void UpdateProduct(int id, string name, int qty, double price)
    {
        if (inventory.ContainsKey(id))
        {
            inventory[id].ProductName = name;
            inventory[id].Quantity = qty;
            inventory[id].Price = price;
            Console.WriteLine("Product updated.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    // Delete product
    public void DeleteProduct(int id)
    {
        if (inventory.Remove(id))
            Console.WriteLine("Product deleted.");
        else
            Console.WriteLine("Product not found.");
    }

    // Display all products
    public void DisplayProducts()
    {
        Console.WriteLine("\nInventory List:");
        foreach (var item in inventory.Values)
        {
            Console.WriteLine(item);
        }
    }
}

// Main
class Program
{
    static void Main(string[] args)
    {
        InventorySystem system = new InventorySystem();

        // Adding Products
        system.AddProduct(new Product(101, "Laptop", 5, 55000));
        system.AddProduct(new Product(102, "Mouse", 10, 800));
        system.AddProduct(new Product(103, "Keyboard", 7, 1500));

        system.DisplayProducts();

        // Updating a product
        system.UpdateProduct(102, "Wireless Mouse", 12, 1200);

        // Deleting a product
        system.DeleteProduct(103);

        system.DisplayProducts();
    }
}
