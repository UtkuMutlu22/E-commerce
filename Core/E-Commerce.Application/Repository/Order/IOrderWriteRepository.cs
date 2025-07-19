namespace E_Commerce.Application.Repository
{
    using E_Commerce.Domain.Entities;

    /// <summary>
    /// Represents a write repository for <see cref="Order"/> entities.
    /// </summary>
    public interface IOrderWriteRepository : IWriteRepository<Order>
    {
    }
}
