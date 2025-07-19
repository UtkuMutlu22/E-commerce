namespace E_Commerce.Domain.Entities
{
    using E_Commerce.Domain.Entities.Common;

    /// <summary>
    /// Represents a product in the e-commerce system.
    /// </summary>
    public class Product : BaseEntitiy
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the available stock quantity of the product.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Gets or sets the collection of orders that include this product.
        /// </summary>
        public ICollection<Order>? Orders { get; set; }
    }
}
