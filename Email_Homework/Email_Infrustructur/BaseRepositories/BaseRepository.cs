using Email_Application.IServer;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Email_Infrustructur.BaseRepositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AddAplication _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(AddAplication context, DbSet<T> dbset)
        {
            _context = context;
            _dbSet = dbset;
        }

        public async Task<T> Create(T entity)
        {
            var result = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> Delete(Expression<Func<T, bool>> expression)
        {
            var result = await _dbSet.FirstOrDefaultAsync(expression);

            if (result == null)
            {
                return false;
            }

            _context.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByAny(Expression<Func<T, bool>> expression)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(expression);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> Update(T entity)
        {
            var result = _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return result.Entity;

        }


    }
}
