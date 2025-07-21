namespace E_Commerce.API.Controllers
{
    using System.Globalization;

    using E_Commerce.Application.Repository;
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
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class with the specified product write repository.
        /// </summary>
        /// <param name="productWriteRepository">The repository used for writing product data to the database.</param>
        public ProductsController(
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IOrderReadRepository orderReadRepository,
            IOrderWriteRepository orderWriteRepository,
            ICustomerReadRepository customerReadRepository,
            ICustomerWriteRepository customerWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
        }

        /// <summary>
        /// Adds a set of sample products to the database.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet]
        public async Task GetAsync()
        {
            //_ = await this._productWriteRepository.AddRangeAsync(
            //[
            //    new () { Name = "Product 7", Price = 100, Stock = 1, Id = Guid.NewGuid(), CreatedDate = DateTime.Now },
            //    new () { Name = "Product 8", Price = 50, Stock = 5, Id = Guid.NewGuid(), CreatedDate = DateTime.Now },
            //    new () { Name = "Product 9", Price = 6, Stock = 123, Id = Guid.NewGuid(), CreatedDate = DateTime.Now }
            //]);

            //Product c = await _productReadRepository.GetByIdAsync("C7DA42FE-F7A1-4BCC-8FFD-05C0AF2EE6E3",false);
            //c.Name = "Updated Product Name Change";


            //await _productWriteRepository.AddAsync(new() { Name = "C product", Stock = 10, Price = decimal.Parse("12.50", CultureInfo.InvariantCulture), CreatedDate = DateTime.Now, Id = Guid.NewGuid() });
            //this._productWriteRepository.SaveAsync();

            //Customer c = new Customer()
            //{
            //    Name = "Utku",
            //    Id = Guid.NewGuid(),
            //    CreatedDate = DateTime.Now
            //};
            //var pr1 = new Product() { Name = "Product 7", Price = 100, Stock = 1, Id = Guid.NewGuid(), CreatedDate = DateTime.Now };
            //var pr2 = new Product() { Name = "Product 8", Price = 100, Stock = 1, Id = Guid.NewGuid(), CreatedDate = DateTime.Now }; var p = new List<Product>();
            //p.Add(pr1);
            //p.Add(pr2);
            //await _productWriteRepository.AddAsync(pr1);
            //await _productWriteRepository.AddAsync(pr2);
            //await _orderWriteRepository.AddAsync(new() { Description = "aaaaa", Address = "Maltepe" });
            //await _orderWriteRepository.AddAsync(new() { Description = "bbb", Address = "Zümrütevler", CustomerId = c.Id});
            //await _orderWriteRepository.SaveAsync();

            var order = await _orderReadRepository.GetByIdAsync("9D11855A-6F31-4DEC-B6C1-32270B45CFE1");
            order.Address = "İstanbul";
            _orderWriteRepository.SaveAsync();

        }

        /// <summary>
        /// Retrieves a product by its unique ID from the database asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>
        /// Returns 200 OK with the product data if found; otherwise, returns 404 Not Found.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            Domain.Entities.Product? product = await this._productReadRepository.GetByIdAsync(id);
            return this.Ok(product);
        }
    }
}
