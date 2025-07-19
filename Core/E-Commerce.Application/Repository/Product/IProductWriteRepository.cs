namespace E_Commerce.Application.Repository
{
    using E_Commerce.Domain.Entities;

    /// <summary>
    /// Represents a write repository for <see cref="Product"/> entities.
    /// Provides methods for adding, removing, and updating products.
    /// </summary>
    public interface IProductWriteRepository : IWriteRepository<Product>
    {
    }
}
