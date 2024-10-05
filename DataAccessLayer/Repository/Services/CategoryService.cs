using DataAccessLayer.Models;
using DataAccessLayer.Repository.Interface;
using DataAccessLayer.Repository.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Services
{
    public class CategoryService : ICategoryRepository
    {
        public Category GetCategory(short id) => CategoryManager.Instance.GetCategory(id);

        public List<Category> GetAllCategory() => CategoryManager.Instance.GetAllCategory();

        public void AddCategory(Category category) => CategoryManager.Instance.AddCategory(category);

        public void UpdateCategory(Category category) => CategoryManager.Instance.UpdaterCategory(category);

        public int DeleteCategory(short id) => CategoryManager.Instance.DeleteCategory(id);

    }
}
