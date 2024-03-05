using ClassLibrary1.DataAccess.Data;
using ClassLibrary1.DataAccess.Repoistory.IRepoistory;
using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DataAccess.Repoistory
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }



        public void save()
        {
            _db.SaveChanges();
        }

        public void update(Product product)
        {
            _db.products.Update(product);
        }


        
    }
}
