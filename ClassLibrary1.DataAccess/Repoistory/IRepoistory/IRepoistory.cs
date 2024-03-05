using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DataAccess.Repoistory.IRepoistory
{
    public interface IRepoistory <T>where T : class
    {
        IEnumerable<T> GetAll(string? includeProperties = null);
          T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);

        void Delete(T entity);
        void Add(T entity);
        void DeleteRange(IEnumerable<T> entities);


    }
}
