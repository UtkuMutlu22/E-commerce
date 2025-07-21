namespace E_Commerce.Application.Repository
{
    using E_Commerce.Domain.Entities.Common;

    /// <summary>
    /// Defines write operations for a repository of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The entity type, which must inherit from <see cref="BaseEntitiy"/>.</typeparam>
    public interface IWriteRepository<T> : IRepository<T>
        where T : BaseEntitiy
    {
        /// <summary>
        /// Asynchronously adds an entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>True if the entity was added; otherwise, false.</returns>
        Task<bool> AddAsync(T entity);

        /// <summary>
        /// Asynchronously adds a range of entities to the repository.
        /// </summary>
        /// <param name="entities">The entities to add.</param>
        /// <returns>True if the entities were added; otherwise, false.</returns>
        Task<bool> AddRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// Asynchronously removes an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to remove.</param>
        /// <returns>True if the entity was removed; otherwise, false.</returns>
        Task<bool> RemoveAsync(string id);

        /// <summary>
        /// Removes a range of entities from the repository.
        /// </summary>
        /// <param name="entities">The entities to remove.</param>
        /// <returns>True if the entities were removed; otherwise, false.</returns>
        bool RemoveRange(IEnumerable<T> entities);

        /// <summary>
        /// Updates an entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>True if the entity was updated; otherwise, false.</returns>
        bool Update(T entity);

        /// <summary>
        /// Updates a range of entities in the repository.
        /// </summary>
        /// <param name="entities">The entities to update.</param>
        /// <returns>True if the entities were updated; otherwise, false.</returns>
        bool UpdateRange(IEnumerable<T> entities);

        /// <summary>
        /// Saves changes made in the repository.
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// </summary>
        Task SaveAsync();
    }
}
