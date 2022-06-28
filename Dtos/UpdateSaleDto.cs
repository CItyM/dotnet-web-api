using Supplies.Model;

namespace Supplies.Dtos;

public class UpdateSaleDto
{
    public bool CouponUsed { get; set; }
    public Customer Customer { get; set; } = null!;
    public IEnumerable<Item> Items { get; set; } = null!;
    public string PurchaseMethod { get; set; } = null!;
    public string StoreLocation { get; set; } = null!;
}