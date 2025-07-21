namespace E_Commerce.Persistance.Concretes
{
    using System.Linq.Expressions;

    using E_Commerce.Application.Repository;
    using E_Commerce.Domain.Entities.Common;
    using E_Commerce.Persistance.Contexts;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Generic read repository implementation for accessing entities from the database.
    /// </summary>
    /// <typeparam name="T">Entity type that inherits from <see cref="BaseEntitiy"/>.</typeparam>
    public class ReadRepository<T> : IReadReporistory<T>
        where T : BaseEntitiy
    {
        private readonly ECommerceDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The database context used for querying entities.</param>
        public ReadRepository(ECommerceDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets the database set (table) for the specified entity type.
        /// </summary>
        public DbSet<T> Table
        {
            get
            {
                return this._context.Set<T>();
            }
        }

        /// <summary>
        /// Retrieves all entities from the database.
        /// </summary>
        /// <param name="tracking">Specifies whether change tracking is enabled.</param>
        /// <returns>An <see cref="IQueryable{T}"/> of all entities.</returns>
        public IQueryable<T> GetAll(bool tracking = true)
        {
            IQueryable<T> query = this.Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
                return query;
            }

            // If tracking is enabled, return the queryable with tracking
            return query;
        }

        /// <summary>
        /// Retrieves entities that match the specified condition.
        /// </summary>
        /// <param name="predicate">The condition to match.</param>
        /// <param name="tracking">Specifies whether change tracking is enabled.</param>
        /// <returns>An <see cref="IQueryable{T}"/> of matching entities.</returns>
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true)
        {
            IQueryable<T> query = this.Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
                return query;
            }

            // If tracking is enabled, return the queryable with tracking
            return this.Table.Where(predicate);
        }

        /// <summary>
        /// Asynchronously retrieves a single entity that matches the specified predicate.
        /// </summary>
        /// <param name="predicate">An expression to filter the entity.</param>
        /// <param name="tracking">Specifies whether change tracking is enabled.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the matched entity,
        /// or <c>null</c> if no match is found.
        /// </returns>
        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate, bool tracking = true)
        {
            IQueryable<T> query = this.Table.AsQueryable();
            if (!tracking)
            {
                query = this.Table.AsNoTracking();
            }

            // If tracking is enabled, return the queryable with tracking
            return await query.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Asynchronously retrieves an entity by its string representation of a <see cref="Guid"/> identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity as a string.</param>
        /// <param name="tracking">Specifies whether change tracking is enabled.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the entity with the specified ID,
        /// or <c>null</c> if not found.
        /// </returns>
        public async Task<T?> GetByIdAsync(string id, bool tracking = true)
        {
            IQueryable<T> query = this.Table.AsQueryable();
            if (!tracking)
            {
                query = this.Table.AsNoTracking();
            }

            // If tracking is enabled, return the queryable with tracking
            return await query.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
        }

        /// <summary>
        /// Checks whether an entity with the specified ID exists.
        /// </summary>
        /// <param name="id">The ID to check.</param>
        /// <returns>True if an entity exists; otherwise, false.</returns>
        public Task<bool> AnyAsync(string id)
        {
            return this.Table.AnyAsync(data => data.Id == Guid.Parse(id));
        }

        /// <summary>
        /// Checks whether any entity satisfies the specified condition.
        /// </summary>
        /// <param name="predicate">The condition to evaluate.</param>
        /// <returns>True if any entity matches; otherwise, false.</returns>
        public Task<bool> AnyAsync(Func<T, bool> predicate)
        {
            return Task.FromResult(this.Table.Any(predicate));
        }

        /// <summary>
        /// Counts all entities in the database.
        /// </summary>
        /// <returns>The total count of entities.</returns>
        public Task<int> CountAsync()
        {
            return this.Table.CountAsync();
        }

        /// <summary>
        /// Counts entities that satisfy the specified condition.
        /// </summary>
        /// <param name="predicate">The condition to evaluate.</param>
        /// <returns>The number of matching entities.</returns>
        public Task<int> CountAsync(Func<T, bool> predicate)
        {
            return Task.FromResult(this.Table.Count(predicate));
        }
    }
}
