using E_Commerce.Application.Repository;
using E_Commerce.Domain.Entities;
using E_Commerce.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Persistance.Concretes
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(E_CommerceDbContext context) : base(context)
        {
        }
    }
}
