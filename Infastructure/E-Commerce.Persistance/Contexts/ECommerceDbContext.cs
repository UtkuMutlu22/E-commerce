namespace E_Commerce.Persistance.Contexts
{
    using E_Commerce.Domain.Entities;
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
