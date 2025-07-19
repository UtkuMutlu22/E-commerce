namespace E_Commerce.Application.Repository
{
    using E_Commerce.Domain.Entities;

    /// <summary>
    /// Provides read-only repository operations for <see cref="Product"/> entities.
    /// </summary>
    public interface IProductReadRepository : IReadReporistory<Product>
    {
    }
}
