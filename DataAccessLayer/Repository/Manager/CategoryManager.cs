using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Manager
{
    public class CategoryManager
    {
        //using singleton pattern
        private static CategoryManager instance = null;
        public static readonly object instanceLock = new object();
        private CategoryManager() { }
        public static CategoryManager Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryManager();
                    }
                    return instance;
                }
            }
        }
        //------------------------------------------

        public Category GetCategory(int id)
        {
            Category category = new Category();
            using (var context = new FunewsManagementDbContext())
            {
                category = context.Categories.FirstOrDefault(x => x.CategoryId == id);

            }
            return category;
        }

        public List<Category> GetAllCategory()
        {
            List<Category> list = new List<Category>();
            using (var context = new FunewsManagementDbContext())
            {
                list = context.Categories.ToList();
            }
            return list;
        }

        public void AddCategory(Category category)
        {
            try
            {
                using (var context = new FunewsManagementDbContext())
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdaterCategory(Category category)
        {
            try
            {
                using (var context = new FunewsManagementDbContext())
                { 
                    Category oldCategory = context.Categories.FirstOrDefault(x => x.CategoryId==category.CategoryId);
                    if (oldCategory != null)
                    {
                        oldCategory.CategoryName = category.CategoryName;
                        oldCategory.CategoryDesciption = category.CategoryDesciption;
                        context.SaveChanges();
                    }
                }


            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int DeleteCategory(short id)
        {
            try
            {
                using (var context = new FunewsManagementDbContext())
                {
                    List<NewsArticle> newsArticles = context.NewsArticles.Where(x=>x.CategoryId==id).ToList();
                    if (newsArticles.Any())
                    {
                        return 0;
                    }
                    else
                    {
                        Category category = context.Categories.FirstOrDefault(x=>x.CategoryId==id);
                        if (category != null) { 
                        context.Categories.Remove(category);
                        context.SaveChanges();
                        return 1;
                        }
                        else { return 2; }
                    }

                }

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
     }
}
