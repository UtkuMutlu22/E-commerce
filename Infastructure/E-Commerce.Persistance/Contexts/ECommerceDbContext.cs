namespace E_Commerce.Persistance.Contexts
{
    using System.Threading;
    using System.Threading.Tasks;

    using E_Commerce.Domain.Entities;
    using E_Commerce.Domain.Entities.Common;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents the Entity Framework database context for the E-Commerce application.
    /// </summary>
    public class ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
        : DbContext(options)
    {
        /// <summary>
        /// Gets or sets the customers table.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the products table.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the orders table.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Overrides SaveChangesAsync to automatically set CreatedDate and UpdateDate
        /// for entities derived from BaseEntity based on their EntityState.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <returns>The number of state entries written to the database.</returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<BaseEntitiy>> entries = this.ChangeTracker.Entries<BaseEntitiy>();
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<BaseEntitiy> entity in entries)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedDate = DateTime.Now;
                    entity.Entity.Id = Guid.NewGuid();
                }
                else if (entity.State == EntityState.Modified)
                {
                    entity.Entity.UpdateDate = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Configures the model that was discovered by convention from the entity types
        /// exposed in <see cref="DbSet{TEntity}"/> properties on this context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
