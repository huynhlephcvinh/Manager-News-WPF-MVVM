using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Interface
{
    public interface INewsArticleRepository
    {
        public List<NewsArticle> GetAllNewsArticle();
        public void AddNews(NewsArticle newsArticle);
        public void AddTagToNews(string newsArticleId, Tag tag);
        public void UpdateNews(NewsArticle newsArticle);
        public int DeleteNews(string id);
        public void RemoveTag(NewsArticle newsArticle, Tag tag);
        public List<NewsArticle> GetAllListReportStatistic(DateTime startTime, DateTime endTime);
    }
}
