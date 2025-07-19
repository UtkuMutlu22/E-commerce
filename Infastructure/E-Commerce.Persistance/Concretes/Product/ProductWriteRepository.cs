namespace E_Commerce.Persistance.Concretes
{
    using E_Commerce.Application.Repository;
    using E_Commerce.Domain.Entities;
    using E_Commerce.Persistance.Contexts;

    /// <summary>
    /// Provides write operations for the Product entity using the database context.
    /// </summary>
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductWriteRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public ProductWriteRepository(ECommerceDbContext context)
            : base(context)
        {
        }
    }
}
