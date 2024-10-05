using BusinessLogicLayer.Command;
using DataAccessLayer.Models;
using DataAccessLayer.Repository.Interface;
using DataAccessLayer.Repository.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BusinessLogicLayer.ViewModels
{
    public class InsertOrUpdateNewsViewModel : BaseViewModel
    {
        private NewsArticle _newsArticle;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IWindowService _windowService;
        public ICategoryRepository _categoriesRepository;
        public Action CloseAction { get; set; }
        public INewsArticleRepository _newsArticleRepository;
        private SystemAccount _account;
        private ObservableCollection<Category> _categories;


        public SystemAccount Account
        {
            get { return _account; }
            set { _account = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; OnPropertyChanged(); }
        }
      
        public NewsArticle CurrentNews
        {
            get { return _newsArticle; }
            set { _newsArticle = value; OnPropertyChanged(); }
        }

        public ICommand OKNewsCommand { get; set; }
        public ICommand UpdateNewsCommand { get; set; }
        public ICommand CloseNewsCommand { get; set; }

        public InsertOrUpdateNewsViewModel(IWindowService windowService, IMessageBoxService messageBoxService, SystemAccount sa, NewsArticle? news =null)
        {
            _categoriesRepository = new CategoryService();
            _newsArticleRepository = new NewsArticleService();
            _messageBoxService = messageBoxService;
            _windowService = windowService;
            Account = sa;
            if(news == null) 
            { CurrentNews = new NewsArticle();
            }
            else
            {
                CurrentNews = news;
            }
            
            Categories = new ObservableCollection<Category>(_categoriesRepository.GetAllCategory());
            OKNewsCommand = new RelayCommand(OKNews, CanOKNews);
            UpdateNewsCommand = new RelayCommand(UpdateNews, CanUpdateNews);
            CloseNewsCommand = new RelayCommand(CloseNews, CanCloseNews);
        }

        private bool CanCloseNews(object obj)
        {
            return true;
        }

        private void CloseNews(object obj)
        {
            _windowService.CloseWindow(obj);
        }

        private bool CanUpdateNews(object obj)
        {
            return true;
        }

        private void UpdateNews(object obj)
        {
            NewsArticle na = CurrentNews;
            na.ModifiedDate = DateTime.Now;
            if (string.IsNullOrEmpty(na.NewsTitle) == false && string.IsNullOrEmpty(na.NewsContent) == false)
            {
                _newsArticleRepository.UpdateNews(na);
                if (CloseAction != null)
                {
                    CloseAction();

                }
            }
            else{
                _messageBoxService.Show("Title and Content is not empty");
            }
        }

        private bool CanOKNews(object obj)
        {
            return true;
        }

        private void OKNews(object obj)
        {
            byte[] randomBytes = new byte[5]; // 5 bytes sẽ tạo ra 8 ký tự sau khi mã hóa Base64
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }

            // Mã hóa Base64 và chỉ lấy 7 ký tự đầu tiên
            string base64String = Convert.ToBase64String(randomBytes)
                                        .Replace('+', '-') // Thay đổi ký tự để Base64 URL-safe
                                        .Replace('/', '_') // Thay đổi ký tự để Base64 URL-safe
                                        .Substring(0, 7);

            NewsArticle na = CurrentNews;
            na.NewsArticleId = base64String.ToString();
            na.CreatedDate = DateTime.Now;
            na.NewsStatus = true;
            na.CreatedById = Account.AccountId;
            na.ModifiedDate = DateTime.Now;
            if (string.IsNullOrEmpty(na.NewsTitle) == false && string.IsNullOrEmpty(na.NewsContent) == false)
            {
                _newsArticleRepository.AddNews(na);
                if (CloseAction != null)
                {
                    CloseAction();

                }
                //CloseAction?.Invoke();
                //_windowService.CloseWindow(obj);
            }
            else
            {
                _messageBoxService.Show("Title and Content is not empty");
            }
        }
    }
}
