using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Interface
{
    public interface ICategoryRepository
    {
        public Category GetCategory(short id);
        public List<Category> GetAllCategory();
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
        public int DeleteCategory(short id);
    }
}
