﻿namespace E_Commerce.Domain.Entities.Common
{
    public abstract class BaseEntitiy
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
