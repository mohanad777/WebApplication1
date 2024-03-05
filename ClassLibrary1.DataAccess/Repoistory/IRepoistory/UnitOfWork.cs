using ClassLibrary1.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DataAccess.Repoistory.IRepoistory
{
    public class UnitOfWork : IUniteOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepoistory category { get; private set; }

        public IProductRepository product { get; private set; }

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            category = new CategoryRepository(_db);
            product= new ProductRepository(_db);    

        }

      

        public void save()
        {
         _db.SaveChanges();
        }
    }
}
