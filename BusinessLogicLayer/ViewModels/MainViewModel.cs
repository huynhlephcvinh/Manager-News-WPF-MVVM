using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAccessLayer.Models;
using DataAccessLayer.Repository.Interface;
using DataAccessLayer.Repository.Manager;
using DataAccessLayer.Repository.Services;
using BusinessLogicLayer.Command;


namespace BusinessLogicLayer.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IWindowService _windowService;
        public INewsArticleRepository _newsArticleRepository;
        public ICategoryRepository _categoriesRepository;

        private ObservableCollection<NewsArticle> _newsArticle;

        public ObservableCollection<NewsArticle> NewsArticles
        {
            get { return _newsArticle; }
            set { _newsArticle = value; OnPropertyChanged(); }
        }
        //public ObservableCollection<Tag> Tags { get; } = new ObservableCollection<Tag>();

        public ICommand LoginCommand { get; set; }

        private void LoadData()
        {
            NewsArticles = new ObservableCollection<NewsArticle>(_newsArticleRepository.GetAllNewsArticle());
            foreach (NewsArticle newarticle in NewsArticles)
            {
                newarticle.Category = _categoriesRepository.GetCategory((short)newarticle.CategoryId);
            }
            //Tags.Clear();
            //foreach (NewsArticle newarticle in NewsArticles)
            //{
            //    foreach (var tag in newarticle.Tags)
            //    {
            //        Tags.Add(tag);
            //    }
            //}

        }



        public MainViewModel(IWindowService windowService)
        {
            _newsArticleRepository = new NewsArticleService();
            _categoriesRepository = new CategoryService();
            LoadData();
            LoginCommand = new RelayCommand(LoginUserCommand, CanLoginCommand);
            _windowService = windowService;
        }

        private bool CanLoginCommand(object obj)
        {
            return true;
        }

        private void LoginUserCommand(object obj)
        {
            _windowService.OpenLoginWindow();


        }
    }
}
