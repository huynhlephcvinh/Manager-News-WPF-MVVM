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
    public class ManageNewsArticleViewModel : BaseViewModel
    {
        private NewsArticle _newsArticle;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IWindowService _windowService;
        public ICategoryRepository _categoriesRepository;
        public ISystemAccountRepository _systemAccountRepository;
        public INewsArticleRepository _newsArticleRepository;
        public ITagRepository _tagsRepository;
        private ObservableCollection<NewsArticle> _newsArticles;
        private SystemAccount _account;
        private Tag _tagchoosedtoremove;
        public SystemAccount Account
        {
            get { return _account; }
            set { _account = value; OnPropertyChanged(); }
        }
        public ObservableCollection<NewsArticle> NewsArticles
        {
            get { return _newsArticles; }
            set { _newsArticles = value; OnPropertyChanged(); }
        }
        public NewsArticle CurrentNews
        {
            get { return _newsArticle; }
            set { _newsArticle = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Tag> Tags { get; } = new ObservableCollection<Tag>();
        public ObservableCollection<Tag> AvailableTags { get; } = new ObservableCollection<Tag>();

        private Tag _selectedTag;
        public Tag SelectedTag
        {
            get => _selectedTag;
            set
            {
                _selectedTag = value;
                OnPropertyChanged();
            }
        }

        public Tag TagToRemove
        {
            get { return _tagchoosedtoremove; }
            set { _tagchoosedtoremove = value;OnPropertyChanged(); }
        }

        public ICommand AddTagCommand { get; }
        public ICommand RemoveTagCommand { get; }
        public ICommand AddNewsCommand {  get; set; }
        public ICommand UpdateNewsCommand { get; set; }
        public ICommand DeteleNewsCommand { get; set; }
        private void LoadData()
        {
            NewsArticles = new ObservableCollection<NewsArticle>(_newsArticleRepository.GetAllNewsArticle());
            foreach (NewsArticle newarticle in NewsArticles)
            {
                newarticle.Category = _categoriesRepository.GetCategory((short)newarticle.CategoryId);
                newarticle.CreatedBy = _systemAccountRepository.GetSystemAccount((short)newarticle.CreatedById);
            }
            CurrentNews = new NewsArticle();
            var availableTags = _tagsRepository.GetAllTag();
            AvailableTags.Clear();
            foreach (var tag in availableTags)
            {
                AvailableTags.Add(tag);
            }

        }

        public ManageNewsArticleViewModel(IWindowService windowService, IMessageBoxService messageBoxService, SystemAccount sa) 
        {
            _newsArticleRepository = new NewsArticleService();
            _categoriesRepository = new CategoryService();
            _systemAccountRepository = new SystemAccountService();
            _tagsRepository = new TagService();
            LoadData();
            Account = sa;
            _messageBoxService = messageBoxService;
            _windowService = windowService;
           

            AddNewsCommand = new RelayCommand(AddNews, CanAddNews);
            AddTagCommand = new RelayCommand(AddTag, CanAddTag);
            UpdateNewsCommand = new RelayCommand(UpdateNews, CanUpdateNews);
            DeteleNewsCommand = new RelayCommand(DeleteNews, CanDeleteNews);
            RemoveTagCommand = new RelayCommand(RemoveTagFromNewsArticle, CanRemoveTag);
        }

        private bool CanRemoveTag(object obj)
        {
            return true;
        }

        private void RemoveTagFromNewsArticle(object obj)
        {
            if (CurrentNews != null && TagToRemove != null)
            {
                _newsArticleRepository.RemoveTag(CurrentNews, TagToRemove);
                LoadData();
            }
            else
            {
                _messageBoxService.Show("Error");
            }
        }

        private bool CanDeleteNews(object obj)
        {
            return true;
        }

        private void DeleteNews(object obj)
        {
            try
            {
                if (_messageBoxService.ShowMessageBoxYesNo() == 1)
                {
                    string id = CurrentNews.NewsArticleId;
                    if (_newsArticleRepository.DeleteNews(id) == 1)
                    {
                        LoadData();
                    }
                    else
                    {
                        _messageBoxService.Show("No search News to delete");
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex) 
            {
                _messageBoxService.ShowError(ex);
            }
            }

        private bool CanUpdateNews(object obj)
        {
            return true;
        }

        private void UpdateNews(object obj)
        {
            if (string.IsNullOrEmpty(CurrentNews.NewsTitle) == false && string.IsNullOrEmpty(CurrentNews.NewsContent) == false)
            {
                if (_windowService.InsertOrUpdateNews(false, Account, CurrentNews))
                {
                    LoadData();
                }
            }
            else
            {
                _messageBoxService.Show("You must choose one news to update");
                return;
            }
   
            
        }

        private bool CanAddTag(object obj)
        {
            return true;
        }

        private void AddTag(object obj)
        {
            try
            {
                _newsArticleRepository.AddTagToNews(CurrentNews.NewsArticleId, SelectedTag);
                Tags.Add(SelectedTag);
                CurrentNews.Tags.Add(SelectedTag);
                SelectedTag = null;
                LoadData();
            }catch (Exception ex)
            {
                _messageBoxService.ShowError(ex);
            }
        }

        private bool CanAddNews(object obj)
        {
            return true;
        }

        private void AddNews(object obj)
        {
            if (_windowService.InsertOrUpdateNews(true, Account))
            {
                LoadData();
            }
        }
    }
}
