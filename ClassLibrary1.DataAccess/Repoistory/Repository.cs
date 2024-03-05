using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.DataAccess.Data;
using ClassLibrary1.DataAccess.Repoistory.IRepoistory;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.DataAccess.Repoistory
{
    public class Repository<T> : IRepoistory<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;
      public  Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbset = _db.Set<T>();  //_db.categories()==dbset
        }
        public void Add(T entity)
        {
            dbset.Add(entity);  
        }

        public void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            dbset.RemoveRange(entities);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null )
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var IncludeProperty in includeProperties.
                    Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))


                {
                    query.Include(IncludeProperty);
                }

            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties=null)
        {
            IQueryable<T> query = dbset;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

            }

            return query.ToList();  
        }

 
    }
}
