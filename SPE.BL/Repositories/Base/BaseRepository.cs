using Microsoft.EntityFrameworkCore;
using SPE.BL.Abstract;
using SPE.BL.Models;
using SPE.DataModel.Abstract;
using SPE.DataModel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<OperationResult> Add(T entity)
        {
            await _set.AddAsync(entity);
            return new OperationResult() { Success = true, StatusCode = HttpStatusCode.Created };
        }

        public OperationResult Delete(T entity)
        {
            _set.Remove(entity);
            return new OperationResult() { Success = true, StatusCode = HttpStatusCode.OK };
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _set.AsNoTracking().Where(expression);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _set.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<OperationResult> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return new OperationResult() { Success = true, StatusCode = HttpStatusCode.OK };
            }
            catch (DbUpdateException ex)
            {
                return new OperationResult() { Message = ex.Message, StatusCode = HttpStatusCode.InternalServerError };
            }
        }

        public OperationResult Update(T entity)
        {
            _set.Update(entity);
            return new OperationResult() { Success = true, StatusCode = HttpStatusCode.OK };
        }
    }
}
