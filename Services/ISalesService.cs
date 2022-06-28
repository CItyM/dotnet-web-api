using Supplies.Model;

namespace Supplies.Services;

public interface ISalesService
{
    Task CreateSaleAsync(Sale sale);
    Task DeleteSaleAsync(string id);
    Task<Sale> GetSaleAsync(string id);
    Task<IEnumerable<Sale>> GetSalesAsync();
    Task UpdateSaleAsync(Sale sale);
}