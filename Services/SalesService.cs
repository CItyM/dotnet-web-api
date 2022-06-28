using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Supplies.Model;
using Supplies.Settings;

namespace Supplies.Services
{
    public class SalesService : ISalesService
    {
        private readonly IMongoCollection<Sale> _collection;
        private readonly FilterDefinitionBuilder<Sale> _filterBuilder = Builders<Sale>.Filter;

        public SalesService(IOptions<MongoDbSettings> settings)
        {
            IMongoClient client = new MongoClient(settings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<Sale>(settings.Value.SalesCollection);
        }

        public async Task CreateSaleAsync(Sale sale)
        {
            await _collection.InsertOneAsync(sale);
        }

        public async Task DeleteSaleAsync(string id)
        {
            var filter = _filterBuilder.Eq(s => s.Id, id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<Sale> GetSaleAsync(string id)
        {
            var filter = _filterBuilder.Eq(s => s.Id, id);
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Sale>> GetSalesAsync()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateSaleAsync(Sale sale)
        {
            var filter = _filterBuilder.Eq(s => s.Id, sale.Id);
            await _collection.ReplaceOneAsync(filter, sale);
        }
    }
}