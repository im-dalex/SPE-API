using System;
using SPE.DataModel.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SPE.BL.Abstract
{
    public interface IBaseRepository<T> where T : class, IBaseEntity, new()
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveAsync();
    }
}
