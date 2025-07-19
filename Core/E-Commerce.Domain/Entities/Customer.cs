namespace E_Commerce.Domain.Entities
{
    using E_Commerce.Domain.Entities.Common;

    /// <summary>
    /// Represents a customer entity in the e-commerce domain.
    /// </summary>
    public class Customer : BaseEntitiy
    {
        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of orders associated with the customer.
        /// </summary>
        public ICollection<Order>? Orders { get; set; }
    }
}
