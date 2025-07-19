﻿using E_Commerce.Domain.Entities.Common;

namespace E_Commerce.Domain.Entities
{
    public class Order : BaseEntitiy
    {
        public string Description { get; set; }
        public string Address { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
