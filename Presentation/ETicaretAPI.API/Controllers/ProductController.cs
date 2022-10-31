/*using ETicaretAPI.Application.Abstraction;*/

using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        /* persistance getproduct func triggered
         private readonly IProductService _productService;


         public ProductController(IProductService productService)
         {
             _productService = productService;
         }
         [HttpGet]
         public IActionResult GetProducts()
         {
             var products = _productService.GetProducts();
             return Ok(products);
         }*/
        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;

        public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
       [HttpGet]
       public async Task Get()
       {
           await _productWriteRepository.AddRangeAsync(new()
           {
               new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10 },
               new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 200, CreatedDate = DateTime.UtcNow, Stock = 220 },
               new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 300, CreatedDate = DateTime.UtcNow, Stock = 130 }

           });
          var count = await _productWriteRepository.SaveAsync();
       }
       [HttpGet("{id}")]
       public async Task<IActionResult> Get(string id)
       {
           Product product = await _productReadRepository.GetByIdAsync(id);
           return Ok(product);
       }
    }
}
