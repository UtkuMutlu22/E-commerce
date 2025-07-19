using E_Commerce.Domain.Entities.Common;

namespace E_Commerce.Domain.Entities
{
    public class Customer : BaseEntitiy
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
