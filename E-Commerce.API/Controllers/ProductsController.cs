namespace E_Commerce.API.Controllers
{
    using E_Commerce.Application.Repository;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Handles product-related HTTP requests.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class with the specified product write repository.
        /// </summary>
        /// <param name="productWriteRepository">The repository used for writing product data to the database.</param>
        public ProductsController(IProductWriteRepository productWriteRepository)
        {
            this._productWriteRepository = productWriteRepository;
        }

        /// <summary>
        /// Adds a set of sample products to the database.
        /// </summary>
        [HttpGet]
        public async void GetAsync()
        {
            _ = await this._productWriteRepository.AddRangeAsync(
            [
                new () { Name = "Product 4", Price = 400, Stock = 40, Id = Guid.NewGuid(), CreatedDate = DateTime.Now },
                new () { Name = "Product 5", Price = 500, Stock = 50, Id = Guid.NewGuid(), CreatedDate = DateTime.Now },
                new () { Name = "Product 6", Price = 600, Stock = 60, Id = Guid.NewGuid(), CreatedDate = DateTime.Now }
            ]);
            this._productWriteRepository.Save();
        }
    }
}
