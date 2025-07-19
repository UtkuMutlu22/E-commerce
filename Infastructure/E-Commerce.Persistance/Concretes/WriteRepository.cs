using E_Commerce.Application.Repository;
using E_Commerce.Domain.Entities.Common;
using E_Commerce.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace E_Commerce.Persistance.Concretes
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntitiy
    {
        private readonly E_CommerceDbContext _context;
        public WriteRepository(E_CommerceDbContext context)
        {
            _context = context;
        }
        public  DbSet<T> Table => _context.Set<T>();
        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                EntityEntry entityEntry = await Table.AddAsync(entity);
                return entityEntry.State == EntityState.Added;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await _context.Set<T>().AddRangeAsync(entities);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(T entity)
        {
            try
            {
                EntityEntry entityEntry = Table.Update(entity);
                return entityEntry.State == EntityState.Modified;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool UpdateRange(IEnumerable<T> entities)
        {
            try
            {
                Table.UpdateRange(entities);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public async Task<bool> RemoveAsync(string id)
        {
            try
            {
                var entity = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
                EntityEntry entityEntry = Table.Remove(entity);
                return entityEntry.State == EntityState.Deleted;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                Table.RemoveRange(entities);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
