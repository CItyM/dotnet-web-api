namespace Supplies.Settings;

public class MongoDbSettings
{
    public string DatabaseName { set; get; } = null!;
    public string SalesCollection { get; set; } = null!;
    public string ConnectionString { get; set; } = null!;
}