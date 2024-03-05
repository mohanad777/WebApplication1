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
    public class CategoryRepository : Repository<Category>, ICategoryRepoistory
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) :base(db) { 
        _db = db;
        
        }

        public void save()
        {
          _db.SaveChanges();
        }

        public void update(Category category)
        {
           _db.categories.Update(category);
        }
    }
}
