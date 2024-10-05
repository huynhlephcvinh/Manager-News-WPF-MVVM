using BusinessLogicLayer.Command;
using DataAccessLayer.Models;
using DataAccessLayer.Repository.Interface;
using DataAccessLayer.Repository.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BusinessLogicLayer.ViewModels
{
    public class ReportStatisticNewsViewModel :BaseViewModel
    {
        private DateTime _startDate;
        private DateTime _endDate;
        private ObservableCollection<NewsArticle> _newsArticles;
        public INewsArticleRepository _newsArticleRepository;

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<NewsArticle> NewsArticles
        {
            get => _newsArticles;
            set
            {
                _newsArticles = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadNewsArticlesCommand { get; }

        public ReportStatisticNewsViewModel()
        {
            _newsArticleRepository = new NewsArticleService(); 
            LoadNewsArticlesCommand = new RelayCommand(LoadNews, CanLoadNews);
        }

        private bool CanLoadNews(object obj)
        {
            return true;
        }

        private void LoadNews(object obj)
        {
            NewsArticles = new ObservableCollection<NewsArticle>(_newsArticleRepository.GetAllListReportStatistic(StartDate, EndDate));
        }
    }
}
