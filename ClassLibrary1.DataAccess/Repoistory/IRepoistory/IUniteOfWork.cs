using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DataAccess.Repoistory.IRepoistory
{
    public interface IUniteOfWork
    {
         ICategoryRepoistory category { get;  }
        IProductRepository product { get; }
        public void save();

    }
}
