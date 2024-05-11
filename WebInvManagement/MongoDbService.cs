using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace WebInvManagement.Pages
{
public class MongoDBService
{
    private readonly IMongoDatabase _database;

    public MongoDBService(IConfiguration config)
    {
        var connectionString = config.GetConnectionString("MongoDBConnection");
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase("productInventory");
    }

    // Example method to access a MongoDB collection
    public IMongoCollection<Product> GetCollection<Product>(string collectionName)
    {
        return _database.GetCollection<Product>(collectionName);
    }
}
}