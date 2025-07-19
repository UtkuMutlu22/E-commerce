namespace E_Commerce.Domain.Entities.Common
{
    /// <summary>
    /// Represents the base entity with common properties for all entities.
    /// </summary>
    public abstract class BaseEntitiy
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entity was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entity was last updated.
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}
