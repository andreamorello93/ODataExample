using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ODataExample.Application.Interfaces
{
    public interface IGenericRepository<TModel, TKey> where TModel : class
    {
        Task<TModel> GetById(TKey id);
        Task<IEnumerable<TModel>> GetAll();
        IQueryable<TModel> Queryable();
        Task<IEnumerable<TModel>> Find(Expression<Func<TModel, bool>> expression);
        Task<TModel> Insert(TModel entity);
        Task<TModel> Update(TModel entity, TKey id);
        Task<IEnumerable<TModel>> AddRange(IEnumerable<TModel> entities);
        Task<bool> Delete(TKey id);
        Task<bool> DeleteRange(IEnumerable<TModel> entities);
    }
}
