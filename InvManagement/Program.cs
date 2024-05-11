using System;
using System.Collections.Generic;

namespace Inventory_Management
{
    internal class Program
    {
        // List to store products
        static List<Product> inventory = new List<Product>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Inventory Management System!");

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                // Display main menu options
                Console.WriteLine("1. Add Physical Product");
                Console.WriteLine("2. Add Digital Product");
                Console.WriteLine("3. View Products");
                Console.WriteLine("4. Update Product");
                Console.WriteLine("5. Remove Product");
                Console.WriteLine("6. Find Product");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
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
                        UpdateProduct();
                        break;
                    case "5":
                        RemoveProduct();
                        break;
                    case "6":
                        FindProduct();
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Function to add a physical product
        static void AddPhysicalProduct()
        {
            Console.WriteLine("Enter Physical Product Details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Price: ");
            double price;
            // Data validation for correct input
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid input. Please enter a valid price:");
            }
            Console.Write("Quantity: ");
            int quantity;
            // Data validation for correct input
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid input. Please enter a valid quantity:");
            }
            Console.Write("Weight (lbs): ");
            double weight;
            // Data validation for correct input
            while (!double.TryParse(Console.ReadLine(), out weight))
            {
                Console.WriteLine("Invalid input. Please enter a valid weight:");
            }
            Console.Write("Barcode (9-digit number): ");
            long barcode;
            // Data validation for correct input
            while (!long.TryParse(Console.ReadLine(), out barcode) || barcode.ToString().Length != 9)
            {
                Console.WriteLine("Invalid input. Please enter a 9-digit number for the barcode:");
            }

            // Create a new PhysicalProduct object and add it to the inventory list
            PhysicalProduct newProduct = new PhysicalProduct(name, description, price, quantity, weight, barcode);
            inventory.Add(newProduct);

            Console.WriteLine("Physical Product added successfully.");
        }

        // Function to add a digital product
        static void AddDigitalProduct()
        {
            Console.WriteLine("Enter Digital Product Details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();

            double price;
            bool validPrice = false;
            do
            {
                Console.Write("Price: ");
                string priceInput = Console.ReadLine();
                validPrice = double.TryParse(priceInput, out price);
                if (!validPrice)
                {
                    Console.WriteLine("Invalid input for price. Please enter a valid number.");
                }
            // Data validation for correct input
            } while (!validPrice);

            int quantity;
            bool validQuantity = false;
            do
            {
                Console.Write("Quantity: ");
                string quantityInput = Console.ReadLine();
                validQuantity = int.TryParse(quantityInput, out quantity);
                if (!validQuantity)
                {
                    Console.WriteLine("Invalid input for quantity. Please enter a valid integer.");
                }
            // Data validation for correct input
            } while (!validQuantity);

            double fileSize;
            bool validFileSize = false;
            do
            {
                Console.Write("File Size (MB): ");
                string fileSizeInput = Console.ReadLine();
                validFileSize = double.TryParse(fileSizeInput, out fileSize);
                if (!validFileSize)
                {
                    Console.WriteLine("Invalid input for file size. Please enter a valid number.");
                }
            } while (!validFileSize);
            Console.Write("Barcode (9-digit number): ");
            long barcode;
            while (!long.TryParse(Console.ReadLine(), out barcode) || barcode.ToString().Length != 9)
            {
                Console.WriteLine("Invalid input. Please enter a 9-digit number for the barcode:");
            }

            // Create a new DigitalProduct object and add it to the inventory list
            DigitalProduct newProduct = new DigitalProduct(name, description, price, quantity, fileSize, barcode);
            inventory.Add(newProduct);

            Console.WriteLine("Digital Product added successfully.");
        }

        // Function to view all products in the inventory
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

        // Function to update product details
        static void UpdateProduct()
        {
            Console.WriteLine("Select a product to update:");
            DisplayProducts();

            Console.Write("Enter the number of the product: ");
            int productIndex = ReadIntInput() - 1;

            if (productIndex >= 0 && productIndex < inventory.Count)
            {
                Product productToUpdate = inventory[productIndex];

                Console.Clear();
                Console.WriteLine($"Updating {inventory[productIndex].Name}, Barcode: {inventory[productIndex].Barcode}");

                Console.WriteLine("Enter updated product details:");
                Console.Write("Name: ");
                productToUpdate.Name = Console.ReadLine();
                Console.Write("Description: ");
                productToUpdate.Description = Console.ReadLine();
                Console.Write("Price: ");
                productToUpdate.Price = ReadDoubleInput();
                Console.Write("Quantity: ");
                productToUpdate.Quantity = ReadIntInput();

                // class validation
                if (productToUpdate is PhysicalProduct)
                {
                    Console.Write("Weight (lbs): ");
                    ((PhysicalProduct)productToUpdate).Weight = ReadDoubleInput();
                }
                else if (productToUpdate is DigitalProduct)
                {
                    Console.Write("File Size (MB): ");
                    ((DigitalProduct)productToUpdate).FileSize = ReadDoubleInput();
                }

                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid product number.");
            }

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey(true);
        }

        // Function to remove a product from the inventory
        static void RemoveProduct()
        {
            Console.WriteLine("Select a product to remove:");
            DisplayProducts();

            Console.Write("Enter the number of the product: ");
            int productIndex = ReadIntInput() - 1 ;

            // Data validation for correct input
            if (productIndex >= 0 && productIndex < inventory.Count)
            {
                inventory.RemoveAt(productIndex);
                Console.WriteLine("Product removed succesfully");
            }
            else
            {
                Console.WriteLine("Invalid product number.");
            }

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey(true);
        }

        // Function to find a product by name or barcode
        static void FindProduct()
        {
            Console.WriteLine("How would you like to find the product?");
            Console.WriteLine("1. By Name");
            Console.WriteLine("2. By Barcode");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    FindProductByName();
                    break;
                case "2":
                    FindProductByBarcode();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        // Function to find a product by name
        static void FindProductByName()
        {
            Console.Write("Enter the name of the product to find: ");
            string name = Console.ReadLine();

            bool found = false;
            foreach (Product product in inventory)
            {
                if (product.Name.ToLower() == name.ToLower())
                {
                    Console.WriteLine("Product found:");
                    Console.WriteLine(product);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Product not found.");
            }

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey(true);
        }

        // Function to find a product by barcode
        static void FindProductByBarcode()
        {
            Console.Write("Enter the barcode of the product to find: ");
            long barcode;
            // Data validation for correct input
            while (!long.TryParse(Console.ReadLine(), out barcode) || barcode.ToString().Length != 9)
            {
                Console.WriteLine("Invalid input. Please enter a 9-digit number for the barcode:");
            }

            bool found = false;
            foreach (Product product in inventory)
            {
                if (product.Barcode == barcode)
                {
                    Console.WriteLine("Product found:");
                    Console.WriteLine(product);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Product not found.");
            }

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey(true);
        }

        // Function to read a double input from the user
        static double ReadDoubleInput()
        {
            double result;
            // Data validation for correct input
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input. Please enter a valid number:");
            }
            return result;
        }

        // Function to read an integer input from the user
        static int ReadIntInput()
        {
            int input;
            // Data validation for correct input
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Invalid input. Please enter a valid number:");
            }
            return input;
        }

        // Function to display all products in the inventory
        static void DisplayProducts()
        {
            Console.WriteLine("Inventory:");
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {inventory[i]}");
            }
        }

        // Abstract class representing a product
        abstract class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
            public long Barcode { get; set; }

            // Constructor
            public Product(string name, string description, double price, int quantity, long barcode)
            {
                Name = name;
                Description = description;
                Price = price;
                Quantity = quantity;
                Barcode = barcode;
            }

            // Override ToString() method to provide custom string representation of the object
            public override string ToString()
            {
                return $"Name: {Name}, Description: {Description}, Price: {Price:C}, Quantity: {Quantity}, Barcode: {Barcode}";
            }
        }

        // Class representing a physical product, inheriting from Product class
        class PhysicalProduct : Product
        {
            public double Weight { get; set; }

            // Constructor
            public PhysicalProduct(string name, string description, double price, int quantity, double weight, long barcode)
                // equivelent of "extends"
                : base(name, description, price, quantity, barcode)
            {
                Weight = weight;
            }

            // Override ToString() method to provide custom string representation of the object
            public override string ToString()
            {
                return base.ToString() + $", Weight: {Weight} lbs";
            }
        }

        // Class representing a digital product, inheriting from Product class
        class DigitalProduct : Product
        {
            public double FileSize { get; set; }

            // Constructor
            public DigitalProduct(string name, string description, double price, int quantity, double fileSize, long barcode)
                // equivelent of "extends"
                : base(name, description, price, quantity, barcode)
            {
                FileSize = fileSize;
            }

            // Override ToString() method to provide custom string representation of the object
            public override string ToString()
            {
                return base.ToString() + $", File Size: {FileSize} MB";
            }
        }
    }
}
