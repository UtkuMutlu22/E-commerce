namespace E_Commerce.Persistance.Concretes
{
    using E_Commerce.Application.Repository;
    using E_Commerce.Domain.Entities;
    using E_Commerce.Persistance.Contexts;

    /// <summary>
    /// Provides read-only operations for <see cref="Customer"/> entities.
    /// </summary>
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerReadRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public CustomerReadRepository(ECommerceDbContext context)
            : base(context)
        {
        }
    }
}
