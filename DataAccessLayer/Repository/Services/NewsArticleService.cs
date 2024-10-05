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
    public class NewsArticleService : INewsArticleRepository
    {
        public List<NewsArticle> GetAllNewsArticle() => NewsArticleManager.Instance.GetAllNewsArticle();

        public void AddNews(NewsArticle newsArticle) => NewsArticleManager.Instance.AddNews(newsArticle);

        public void AddTagToNews(string newsArticleId, Tag tag) => NewsArticleManager.Instance.AddTagToNews(newsArticleId, tag);

        public void UpdateNews(NewsArticle newsArticle) => NewsArticleManager.Instance.UpdaterNews(newsArticle);

        public int DeleteNews(string id) => NewsArticleManager.Instance.DeleteNews(id);

        public void RemoveTag(NewsArticle newsArticle, Tag tag) => NewsArticleManager.Instance.RemoveTag(newsArticle, tag);

        public List<NewsArticle> GetAllListReportStatistic (DateTime startTime, DateTime endTime) => NewsArticleManager.Instance.LoadNewsArticlesReportStatistics(startTime, endTime);
    }
}
