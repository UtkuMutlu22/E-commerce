using E_Commerce.Application.Repository;
using E_Commerce.Domain.Entities.Common;
using E_Commerce.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_Commerce.Persistance.Concretes
{
    public class ReadRepository<T> : IReadReporistory<T> where T : BaseEntitiy
    {
        private readonly E_CommerceDbContext _context;

        public ReadRepository(E_CommerceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = false)
            => Table;
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
            => Table.Where(predicate);
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
            => await Table.FirstOrDefaultAsync(predicate);
        public Task<T> GetByIdAsync(string id, bool tracking = false)
             => Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        public Task<bool> AnyAsync(string id) 
            => Table.AnyAsync(data => data.Id == Guid.Parse(id));
        public Task<bool> AnyAsync(Func<T, bool> predicate) 
            => Task.FromResult(Table.Any(predicate));
        public Task<int> CountAsync() 
            => Table.CountAsync();
        public Task<int> CountAsync(Func<T, bool> predicate) 
            => Task.FromResult(Table.Count(predicate));
    }
}
