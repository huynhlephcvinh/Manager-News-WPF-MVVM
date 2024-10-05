using Azure;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Manager
{
    public class NewsArticleManager
    {
        //using singleton pattern
        private static NewsArticleManager instance = null;
        public static readonly object instanceLock = new object();
        private NewsArticleManager() { }
        public static NewsArticleManager Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NewsArticleManager();
                    }
                    return instance;
                }
            }
        }
        //------------------------------------------

        public List<NewsArticle> GetAllNewsArticle()
        {
            List<NewsArticle> list = new List<NewsArticle>();
            using (var context = new FunewsManagementDbContext())
            {
                list = context.NewsArticles.Where(x => x.NewsStatus == true).Include(na => na.Tags).ToList();
            }
            return list;
        }

        public void AddNews(NewsArticle news)
        {
            try
            {
                using (var context = new FunewsManagementDbContext())
                {
                    context.NewsArticles.Add(news);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddTagToNews(string newsArticleId, Tag tag)
        {
            try
            {
                using (var context = new FunewsManagementDbContext())
                {
                    var newsArticle = context.NewsArticles.Include(na => na.Tags).FirstOrDefault(na => na.NewsArticleId == newsArticleId);
                    if (newsArticle != null)
                    {
                        var existingTag = context.Tags.FirstOrDefault(x => x.TagId == tag.TagId);
                        if (existingTag != null)
                        {
                            newsArticle.Tags.Add(existingTag);
                            context.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void RemoveTag(NewsArticle newsArticle, Tag tagtoremove)
        {
            try
            {
                using (var context = new FunewsManagementDbContext())
                {
                    var oldnewsArticle = context.NewsArticles.Include(na => na.Tags).FirstOrDefault(na => na.NewsArticleId == newsArticle.NewsArticleId);
                    if (oldnewsArticle != null)
                    {
                        var existingTag = context.Tags.FirstOrDefault(x => x.TagId == tagtoremove.TagId);
                        if (existingTag != null && oldnewsArticle.Tags.Contains(existingTag))
                        {
                            oldnewsArticle.Tags.Remove(existingTag);
                            context.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdaterNews(NewsArticle news)
        {
            try
            {
                using (var context = new FunewsManagementDbContext())
                {
                    NewsArticle oldNews = context.NewsArticles.FirstOrDefault(x => x.NewsArticleId == news.NewsArticleId);
                    if (oldNews != null)
                    {
                        oldNews.NewsTitle = news.NewsTitle;
                        oldNews.NewsContent = news.NewsContent;
                        oldNews.CategoryId = news.CategoryId;
                        oldNews.ModifiedDate = news.ModifiedDate;
                        context.SaveChanges();
                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public int DeleteNews(string id)
        {
            try
            {
                using (var context = new FunewsManagementDbContext())
                {
                    NewsArticle news = context.NewsArticles.FirstOrDefault(x => x.NewsArticleId == id);
                    if (news != null)
                    {
                        news.NewsStatus = false;
                        context.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<NewsArticle> LoadNewsArticlesReportStatistics(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<NewsArticle> listReport = new List<NewsArticle>();
                using (var context = new FunewsManagementDbContext())
                {
                    listReport = context.NewsArticles.Where(n => n.CreatedDate >= startDate && n.CreatedDate <= endDate)
                .OrderByDescending(n => n.CreatedDate)
                .ToList();
                }
                return listReport;
            }catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
