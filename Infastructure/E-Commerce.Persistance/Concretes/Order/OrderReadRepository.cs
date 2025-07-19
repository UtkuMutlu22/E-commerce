namespace E_Commerce.Persistance.Concretes
{
    using E_Commerce.Application.Repository;
    using E_Commerce.Domain.Entities;
    using E_Commerce.Persistance.Contexts;

    /// <summary>
    /// Provides read operations for the Order entity using the database context.
    /// </summary>
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderReadRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public OrderReadRepository(ECommerceDbContext context)
            : base(context)
        {
        }
    }
}
