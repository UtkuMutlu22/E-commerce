namespace E_Commerce.Persistance.Concretes
{
    using E_Commerce.Application.Repository;
    using E_Commerce.Domain.Entities.Common;
    using E_Commerce.Persistance.Contexts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    /// <summary>
    /// Represents the write operations for a specific entity type in the repository pattern.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public class WriteRepository<T> : IWriteRepository<T>
        where T : BaseEntitiy
    {
        private readonly ECommerceDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="WriteRepository{T}"/> class.
        /// </summary>
        /// <param name="context">asdadas.</param>
        public WriteRepository(ECommerceDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets the database set for the specified entity type.
        /// </summary>
        public DbSet<T> Table
        {
            get
            {
                return this._context.Set<T>();
            }
        }

        /// <summary>
        /// Asynchronously adds a single entity to the database.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <returns><c>true</c> if the entity was added successfully; otherwise, <c>false</c>.</returns>
        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                EntityEntry entityEntry = await this.Table.AddAsync(entity);
                return entityEntry.State == EntityState.Added;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Asynchronously adds a collection of entities to the database.
        /// </summary>
        /// <param name="entities">The collection of entities to be added.</param>
        /// <returns><c>true</c> if the entities were added successfully; otherwise, <c>false</c>.</returns>
        public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await this._context.Set<T>().AddRangeAsync(entities);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Updates the specified entity in the database.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns><c>true</c> if the update was successful; otherwise, <c>false</c>.</returns>
        public bool Update(T entity)
        {
            try
            {
                EntityEntry entityEntry = this.Table.Update(entity);
                return entityEntry.State == EntityState.Modified;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Updates a collection of entities in the database.
        /// </summary>
        /// <param name="entities">The entities to be updated.</param>
        /// <returns><c>true</c> if the update was successful; otherwise, <c>false</c>.</returns>
        public bool UpdateRange(IEnumerable<T> entities)
        {
            try
            {
                this.Table.UpdateRange(entities);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Asynchronously removes the entity with the specified ID from the database.
        /// </summary>
        /// <param name="id">The ID of the entity to remove.</param>
        /// <returns><c>true</c> if the entity was found and removed; otherwise, <c>false</c>.</returns>
        public async Task<bool> RemoveAsync(string id)
        {
            try
            {
                T? entity = await this.Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
                if (entity == null)
                {
                    return false;
                }

                EntityEntry entityEntry = this.Table.Remove(entity: entity);
                return entityEntry.State == EntityState.Deleted;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Removes a collection of entities from the database.
        /// </summary>
        /// <param name="entities">The entities to be removed.</param>
        /// <returns><c>true</c> if the entities were removed successfully; otherwise, <c>false</c>.</returns>
        public bool RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                this.Table.RemoveRange(entities);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Persists all changes made in the context to the database.
        /// </summary>
        public void Save()
        {
            this._context.SaveChanges();
        }
    }
}
