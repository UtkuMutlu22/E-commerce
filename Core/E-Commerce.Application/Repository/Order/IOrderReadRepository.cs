namespace E_Commerce.Application.Repository
{
    using E_Commerce.Domain.Entities;

    /// <summary>
    /// Provides read-only operations for <see cref="Order"/> entities.
    /// </summary>
    public interface IOrderReadRepository : IReadReporistory<Order>
    {
    }
}