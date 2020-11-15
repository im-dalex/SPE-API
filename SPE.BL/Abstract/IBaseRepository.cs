using System;
using SPE.DataModel.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SPE.BL.Models;

namespace SPE.BL.Abstract
{
    public interface IBaseRepository<T> where T : class, IBaseEntity, new()
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> expression);
        Task<OperationResult> Add(T entity);
        OperationResult Update(T entity);
        OperationResult Delete(T entity);
        Task<OperationResult> SaveAsync();
    }
}
