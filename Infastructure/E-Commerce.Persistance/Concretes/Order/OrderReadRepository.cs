
using E_Commerce.Application.Repository;
using E_Commerce.Domain.Entities;
using E_Commerce.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Persistance.Concretes
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(E_CommerceDbContext context) : base(context)
        {
        }
    }
}
