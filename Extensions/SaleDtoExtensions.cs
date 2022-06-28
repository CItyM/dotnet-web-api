using Supplies.Model;
using Supplies.Dtos;
using MongoDB.Bson;

namespace Supplies.Extensions;

public static class SaleDtoExtensions
{
    public static SaleDto AsDto(this Sale sale)
    {
        return new SaleDto
        {
            Id = sale.Id!,
            CouponUsed = sale.CouponUsed,
            Customer = sale.Customer,
            Items = sale.Items,
            PurchaseMethod = sale.PurchaseMethod,
            SaleDate = sale.SaleDate,
            StoreLocation = sale.StoreLocation
        };
    }

    public static Sale FromCreateDto(this Sale sale, CreateSaleDto saleDto)
    {
        return new Sale
        {
            Id = ObjectId.GenerateNewId().ToString(),
            CouponUsed = saleDto.CouponUsed,
            Customer = saleDto.Customer,
            Items = saleDto.Items,
            PurchaseMethod = saleDto.PurchaseMethod,
            SaleDate = DateTime.UtcNow,
            StoreLocation = saleDto.StoreLocation
        };
    }
    public static Sale FromUpdateDto(this Sale sale, UpdateSaleDto saleDto)
    {
        return sale with
        {
            CouponUsed = saleDto.CouponUsed,
            Customer = saleDto.Customer,
            Items = saleDto.Items,
            PurchaseMethod = saleDto.PurchaseMethod,
            StoreLocation = saleDto.StoreLocation
        };
    }
}