using E_Commerce.Application.Repository;
using E_Commerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async void Get()
        {
            _productWriteRepository.AddRangeAsync(new List<Product>
            {
                new() { Name = "Product 4", Price = 400, Stock = 40,Id=Guid.NewGuid(),CreatedDate=DateTime.Now },
                new() { Name = "Product 5", Price = 500, Stock = 50,Id=Guid.NewGuid(),CreatedDate=DateTime.Now  },
                new() { Name = "Product 6", Price = 600, Stock = 60,Id=Guid.NewGuid(),CreatedDate=DateTime.Now  }
            });
            _productWriteRepository.Save();

        }

    }
}
