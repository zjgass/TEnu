using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface ICategoryDAO
    {
        Category CreateCategory(Category category);

        List<Category> GetCategories();

        Category UpdateCategory(Category category);
    }
}
