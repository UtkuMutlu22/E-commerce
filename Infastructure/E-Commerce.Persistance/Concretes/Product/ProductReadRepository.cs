using E_Commerce.Application.Repository;
using E_Commerce.Domain.Entities;
using E_Commerce.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistance.Concretes
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(E_CommerceDbContext context) : base(context)
        {
        }
    }
}
