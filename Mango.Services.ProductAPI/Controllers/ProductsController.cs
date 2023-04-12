using Mango.Services.ProductAPI.Dtos;
using Mango.Services.ProductAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IUnitOfWork _uow;

    public ProductsController(IUnitOfWork uow)
    {
        _uow = uow;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        return Ok(await _uow.ProductRepository.GetProductsAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        var product=await _uow.ProductRepository.GetProductByIdAsync(id);
        if (product==null) return NotFound("Product not found");
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductDto productDto)
    {
         _uow.ProductRepository.CreateUpdateProduct(productDto);

         if(!await _uow.Complete()) return BadRequest("Product creation failed!");

         return Ok(productDto);
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] ProductDto productDto)
    {
         _uow.ProductRepository.CreateUpdateProduct(productDto);

         if(!await _uow.Complete()) return BadRequest("Product update failed!");

         return Ok(productDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
         var product =await _uow.ProductRepository.GetProductByIdAsync(id);

         if(product==null) return NotFound("Product not found");

         if(!await _uow.Complete()) return BadRequest("Product deletion failed!");

         return Ok();
    }
}