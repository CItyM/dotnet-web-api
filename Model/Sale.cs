using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Supplies.Model;

public record Sale
{
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("couponUsed")]
    public bool CouponUsed { get; set; }
    [BsonElement("customer")]
    public Customer Customer { get; set; } = null!;
    [BsonElement("items")]
    public IEnumerable<Item> Items { get; set; } = null!;
    [BsonElement("purchaseMethod")]
    public string PurchaseMethod { get; set; } = null!;
    [BsonElement("saleDate")]
    public DateTimeOffset SaleDate { get; set; }
    [BsonElement("storeLocation")]
    public string StoreLocation { get; set; } = null!;
}

public class Customer
{
    [BsonElement("age")]
    public int Age { get; set; }
    [BsonElement("email")]
    public string Email { get; set; } = null!;
    [BsonElement("gender")]
    public string Gender { get; set; } = null!;
    [BsonElement("satisfaction")]
    public int Satisfaction { get; set; }
}

public class Item
{
    [BsonElement("name")]
    public string Name { get; set; } = null!;
    [BsonElement("price")]
    public decimal Price { get; set; }
    [BsonElement("quantity")]
    public int Quantity { get; set; }
    [BsonElement("tags")]
    public IEnumerable<string> Tags { get; set; } = null!;
}