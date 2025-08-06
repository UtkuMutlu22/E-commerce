namespace E_Commerce.API.Controllers
{
    using System.Globalization;
    using System.Net;

    using E_Commerce.Application.Repository;
    using E_Commerce.Application.ViewModels.Products;
    using E_Commerce.Domain.Entities;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Handles product-related HTTP requests.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class with the specified product write repository.
        /// </summary>
        /// <param name="productWriteRepository">The repository used for writing product data to the database.</param>
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            this._productWriteRepository = productWriteRepository;
            this._productReadRepository = productReadRepository;
        }

        /// <summary>
        /// Adds a set of sample products to the database.
        /// </summary>
        /// <returns>A <see cref="IEnumerable{T}"/> representing the asynchronous operation.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok(this._productReadRepository.GetAll(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Vm_CreateProduct product)
        {
            await this._productWriteRepository.AddAsync(new()
            {
                Name = product.Name,
                Stock = product.Stock,
                Price = decimal.Parse(product.Price.ToString()),
            });
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Vm_UpdateProduct product)
        {
            Product _product = await _productReadRepository.GetByIdAsync(product.Id);
            _product.Stock = product.Stock;
            _product.Price = decimal.Parse(product.Price.ToString());
            _product.Name = product.Name;
            //track edilmiyor olsaydı update çağrılacaktı
            await this._productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            _productWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
