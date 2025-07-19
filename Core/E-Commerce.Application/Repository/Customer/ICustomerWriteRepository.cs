namespace E_Commerce.Application.Repository
{
    using E_Commerce.Domain.Entities;

    /// <summary>
    /// Represents a write repository for <see cref="Customer"/> entities.
    /// Provides methods for adding, removing, and updating customers.
    /// </summary>
    public interface ICustomerWriteRepository : IWriteRepository<Customer>
    {
    }
}
