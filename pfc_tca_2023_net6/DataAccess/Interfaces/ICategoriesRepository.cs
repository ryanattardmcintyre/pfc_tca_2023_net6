using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface ICategoriesRepository
    {
        IQueryable<Category> GetCategories();

        void AddCategory(Category c);

        Category GetCategory(int id);
    }
}
