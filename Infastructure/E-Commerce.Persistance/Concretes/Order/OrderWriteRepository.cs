namespace E_Commerce.Persistance.Concretes
{
    using E_Commerce.Application.Repository;
    using E_Commerce.Domain.Entities;
    using E_Commerce.Persistance.Contexts;

    /// <summary>
    /// Provides write operations for the Order entity using the database context.
    /// </summary>
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderWriteRepository"/> class.
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderWriteRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public OrderWriteRepository(ECommerceDbContext context)
            : base(context)
        {
        }
    }
}
