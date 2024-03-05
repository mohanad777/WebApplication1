using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DataAccess.Repoistory.IRepoistory
{
    public interface ICategoryRepoistory:IRepoistory<Category>
    {
        void update(Category category);
        void save();

    }
}
