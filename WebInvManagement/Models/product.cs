using MongoDB.Bson;

namespace WebInvManagement.Pages
{
    public abstract class Product
    {
        public ObjectId Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public long Barcode { get; set; }

        // Default constructor
        public Product()
        {
        }

        // Custom constructor
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
}
