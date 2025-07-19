namespace E_Commerce.Persistance.Concretes
{
    using E_Commerce.Application.Repository;
    using E_Commerce.Domain.Entities;
    using E_Commerce.Persistance.Contexts;

    /// <summary>
    /// Provides write operations for <see cref="Customer"/> entities.
    /// </summary>
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerWriteRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public CustomerWriteRepository(ECommerceDbContext context)
            : base(context)
        {
        }
    }
}
