namespace E_Commerce.Application.Repository
{
    using E_Commerce.Domain.Entities.Common;

    /// <summary>
    /// Provides read-only repository operations for entities of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The entity type, which must inherit from <see cref="BaseEntitiy"/>.</typeparam>
    public interface IReadReporistory<T>
        : IRepository<T>
        where T : BaseEntitiy
    {
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <param name="tracking">If true, enables change tracking.</param>
        /// <returns>An <see cref="IQueryable{T}"/> of all entities.</returns>
        IQueryable<T> GetAll(bool tracking = false);

        /// <summary>
        /// Gets entities matching the specified predicate.
        /// </summary>
        /// <param name="predicate">The filter expression.</param>
        /// <returns>An <see cref="IQueryable{T}"/> of matching entities.</returns>
        IQueryable<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets a single entity matching the specified predicate asynchronously.
        /// </summary>
        /// <param name="predicate">The filter expression.</param>
        /// <returns>
        /// A <see cref="Task{T}"/> representing the asynchronous operation.
        /// The result contains the entity if found; otherwise, <c>null</c>.
        /// </returns>
        Task<T?> GetSingleAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets an entity by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <param name="tracking">If true, enables change tracking.</param>
        /// <returns>
        /// A <see cref="Task{T}"/> representing the asynchronous operation.
        /// The result contains the entity if found; otherwise, <c>null</c>.
        /// </returns>
        Task<T?> GetByIdAsync(string id, bool tracking = false);

        /// <summary>
        /// Determines asynchronously whether any entity exists with the specified identifier.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation.</returns>
        Task<bool> AnyAsync(string id);

        /// <summary>
        /// Determines asynchronously whether any entity matches the specified predicate.
        /// </summary>
        /// <param name="predicate">The filter function.</param>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation.</returns>
        Task<bool> AnyAsync(Func<T, bool> predicate);

        /// <summary>
        /// Gets the total count of entities asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task{int}"/> representing the asynchronous operation.</returns>
        Task<int> CountAsync();

        /// <summary>
        /// Gets the count of entities matching the specified predicate asynchronously.
        /// </summary>
        /// <param name="predicate">The filter function.</param>
        /// <returns>A <see cref="Task{int}"/> representing the asynchronous operation.</returns>
        Task<int> CountAsync(Func<T, bool> predicate);
    }
}
