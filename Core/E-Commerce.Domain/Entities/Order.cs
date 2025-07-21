namespace E_Commerce.Domain.Entities
{
    using E_Commerce.Domain.Entities.Common;

    /// <summary>
    /// Represents an order entity in the e-commerce domain.
    /// </summary>
    public class Order : BaseEntitiy
    {
        /// <summary>
        /// Gets or sets the description of the order.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the description of the order.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the address associated with the order.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets the collection of products in the order.
        /// </summary>
        public ICollection<Product>? Products { get; set; }
    }
}
