using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Supplies.Dtos;
using Supplies.Extensions;
using Supplies.Model;
using Supplies.Services;

namespace Supplies.Controllers;

[ApiController]
[Route("api/sales")]
public class SalesController : ControllerBase
{
    private readonly ISalesService _service;
    public SalesController(ISalesService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SaleDto>>> GetSalesAsync()
    {
        try
        {
            IEnumerable<SaleDto> sales = (await _service.GetSalesAsync()).Select(s => s.AsDto());
            return Ok(sales);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SaleDto>> GetSaleAsync(string id)
    {
        try
        {
            Sale sale = await _service.GetSaleAsync(id);

            if (sale is null) return NotFound();

            return Ok(sale.AsDto());
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateSaleAsync(CreateSaleDto saleDto)
    {
        try
        {
            Sale sale = null!;
            sale = sale.FromCreateDto(saleDto);
            await _service.CreateSaleAsync(sale);

            return CreatedAtAction(
                nameof(GetSaleAsync),
                new { id = sale.Id },
                sale.AsDto());
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateSaleAsync(string id, UpdateSaleDto saleDto)
    {
        try
        {
            Sale sale = await _service.GetSaleAsync(id);

            if (sale is null) return NotFound();

            sale = sale.FromUpdateDto(saleDto);
            await _service.UpdateSaleAsync(sale);

            return CreatedAtAction(
               nameof(GetSaleAsync),
               new { id = sale.Id },
               sale.AsDto());
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSaleAsync(string id)
    {
        try
        {
            Sale sale = await _service.GetSaleAsync(id);

            if (sale is null) return NotFound();

            await _service.DeleteSaleAsync(id);

            return NoContent();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}