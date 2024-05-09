using System;
using System.Collections.Generic;

namespace Inventory_Management
{
    internal class Program
    {
        static List<Product> inventory = new List<Product>(); // List to store products

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Inventory Management System!");

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("1. Add Physical Product");
                Console.WriteLine("2. Add Digital Product");
                Console.WriteLine("3. View Products");
                Console.WriteLine("4. Update Product Quantity");
                Console.WriteLine("5. Remove Product");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                Console.WriteLine("");
                Console.WriteLine("");
                string choice = Console.ReadLine();

                // Clear the console before processing user input
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        AddPhysicalProduct();
                        break;
                    case "2":
                        AddDigitalProduct();
                        break;
                    case "3":
                        ViewProducts();
                        break;
                    case "4":
                        UpdateProductQuantity();
                        break;
                    case "5":
                        RemoveProduct();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddPhysicalProduct()
        {
            Console.WriteLine("Enter Physical Product Details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Weight (lbs): ");
            double weight = double.Parse(Console.ReadLine());

            PhysicalProduct newProduct = new PhysicalProduct(name, description, price, quantity, weight);
            inventory.Add(newProduct);

            Console.WriteLine("Physical Product added successfully.");
        }

        static void AddDigitalProduct()
        {
            Console.WriteLine("Enter Digital Product Details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("File Size (MB): ");
            double fileSize = double.Parse(Console.ReadLine());

            DigitalProduct newProduct = new DigitalProduct(name, description, price, quantity, fileSize);
            inventory.Add(newProduct);

            Console.WriteLine("Digital Product added successfully.");

        }

        static void ViewProducts()
        {
            Console.WriteLine("Inventory:");
            foreach (Product product in inventory)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey(true);
            Console.Clear(); // Clear the console before returning to the main menu
        }

        static void UpdateProductQuantity()
        {
            Console.Write("Enter product name to update quantity: ");
            string name = Console.ReadLine();

            Product productToUpdate = inventory.Find(p => p.Name == name);
            if (productToUpdate != null)
            {
                Console.Write("Enter new quantity: ");
                int newQuantity = int.Parse(Console.ReadLine());
                productToUpdate.Quantity = newQuantity;
                Console.WriteLine("Quantity updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        static void RemoveProduct()
        {
            Console.Write("Enter product name to remove: ");
            string name = Console.ReadLine();

            Product productToRemove = inventory.Find(p => p.Name == name);
            if (productToRemove != null)
            {
                inventory.Remove(productToRemove);
                Console.WriteLine("Product removed successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }

    abstract class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, string description, double price, int quantity)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}, Price: {Price:C}, Quantity: {Quantity}";
        }
    }

    class PhysicalProduct : Product
    {
        public double Weight { get; set; }

        public PhysicalProduct(string name, string description, double price, int quantity, double weight)
            : base(name, description, price, quantity)
        {
            Weight = weight;
        }

        public override string ToString()
        {
            return base.ToString() + $", Weight: {Weight} lbs";
        }
    }

    class DigitalProduct : Product
    {
        public double FileSize { get; set; }

        public DigitalProduct(string name, string description, double price, int quantity, double fileSize)
            : base(name, description, price, quantity)
        {
            FileSize = fileSize;
        }

        public override string ToString()
        {
            return base.ToString() + $", File Size: {FileSize} MB";
        }
    }
}
