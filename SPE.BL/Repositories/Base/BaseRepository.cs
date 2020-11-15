using Microsoft.EntityFrameworkCore;
using SPE.BL.Abstract;
using SPE.DataModel.Abstract;
using SPE.DataModel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPE.BL.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity, new()
    {
        private readonly SPEDbContext _context;
        public DbSet<T> _set;
        public BaseRepository(SPEDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public void Add(T entity)
        {
            _set.Add(entity);
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _set.Where(expression);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _set.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _set.FindAsync(id);
        }

        public void Update(T entity)
        {
            _set.Update(entity);
        }
    }
}
