namespace E_Commerce.Persistance.Concretes
{
    using E_Commerce.Application.Repository;
    using E_Commerce.Domain.Entities;
    using E_Commerce.Persistance.Contexts;

    /// <summary>
    /// Provides read operations for the Product entity using the database context.
    /// </summary>
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductReadRepository"/> class.
        /// </summary>
        /// <param name="context">The database context used for data access operations.</param>
        public ProductReadRepository(ECommerceDbContext context)
            : base(context)
        {
        }
    }
}
