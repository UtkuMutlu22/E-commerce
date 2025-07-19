namespace E_Commerce.Application.Repository
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents a generic repository for accessing entities of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Gets the <see cref="DbSet{T}"/> representing the table for the entity type <typeparamref name="T"/>.
        /// </summary>
        DbSet<T> Table { get; }
    }
}