namespace E_Commerce.Application.Repository
{
    using E_Commerce.Domain.Entities;

    /// <summary>
    /// Represents a read-only repository for <see cref="Customer"/> entities.
    /// </summary>
    public interface ICustomerReadRepository : IReadReporistory<Customer>
    {
    }
}
