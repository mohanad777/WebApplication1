using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DataAccess.Repoistory.IRepoistory
{
    public interface IProductRepository : IRepoistory<Product>
    {
        void update(Product product);
        void save();



    }
}
