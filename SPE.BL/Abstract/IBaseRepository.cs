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
        Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> expression);
        Task<T> Add(T entity);
        Task<T> Update(T Entity);
        Task<T> Delete(T entity);
    }
}
