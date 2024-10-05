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
    public class ManageCategoryViewModel : BaseViewModel
    {
        public ICategoryRepository _categoriesRepository;

        private ObservableCollection<Category> _categories;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IWindowService _windowService;

       private Category _category;

        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; OnPropertyChanged(); }
        }

        public Category CurrentCategory
        {
            get { return _category; }
            set { _category = value; OnPropertyChanged(); }
        }
        
        public ICommand ReloadCommand { get; set; }
        public ICommand AddCategoryCommand { get; set; }
        public ICommand UpdateCategoryCommand { get; set; }
        public ICommand DeteleCategoryCommand { get; set; }

        private void LoadData()
        {
            Categories = new ObservableCollection<Category>(_categoriesRepository.GetAllCategory());
            CurrentCategory = new Category();
        }

        public ManageCategoryViewModel(IWindowService windowService,IMessageBoxService messageBoxService) {
            _categoriesRepository = new CategoryService();
            LoadData();

            ReloadCommand = new RelayCommand(Reload, CanReload);
            AddCategoryCommand = new RelayCommand(AddCategory, CanAddCategory);
            UpdateCategoryCommand = new RelayCommand(UpdateCategory, CanUpdateCategory);
            DeteleCategoryCommand = new RelayCommand(DeleteCategory, CanDeleteCategory);
            _messageBoxService = messageBoxService;
            _windowService = windowService;
        }

        private bool CanDeleteCategory(object obj)
        {
            return true;
        }

        private void DeleteCategory(object obj)
        {
            try
            {
                if (_messageBoxService.ShowMessageBoxYesNo() == 1)
                {
                    short id = CurrentCategory.CategoryId;
                    if (_categoriesRepository.DeleteCategory(id) == 1)
                    {
                        LoadData();
                    }
                    else if (_categoriesRepository.DeleteCategory(id) == 0)
                    {
                        _messageBoxService.Show("Category connected with NewsArticle should not delete or No see Category");
                    }
                    else
                    {
                        _messageBoxService.Show("No search Category");
                    }
                }
                else
                {
                    return;
                }


            }catch (Exception ex)
            {
                _messageBoxService.ShowError(ex);
            }
        }

        private bool CanUpdateCategory(object obj)
        {
            return true;
        }

        private void UpdateCategory(object obj)
        {
            Category category = CurrentCategory;
            if (string.IsNullOrEmpty(category.CategoryName) == true && string.IsNullOrEmpty(category.CategoryDesciption) == true)
                
                {
                    _messageBoxService.Show("You must choose one category to update");
                return;
            }
            else
            {
                if (_windowService.InsertOrUpdateCategory(false, category) == true)
                {
                    LoadData();
                }
            }
            


            //Category category = CurrentCategory;
            //if (string.IsNullOrEmpty(category.CategoryName) == false && string.IsNullOrEmpty(category.CategoryDesciption) == false)
            //{
            //    _categoriesRepository.UpdateCategory(category);
            //    LoadData();
            //}
            //else
            //{
            //    _messageBoxService.Show("Name and Description is not empty");
            //}

        }

        private bool CanAddCategory(object obj)
        {
            return true;
        }

        private void AddCategory(object obj)
        {
           if( _windowService.InsertOrUpdateCategory(true) == true)
            {
                LoadData();
            }


           
            //Category category = CurrentCategory;
            //category.CategoryId = 0;
            //if (string.IsNullOrEmpty(category.CategoryName) == false && string.IsNullOrEmpty(category.CategoryDesciption) == false)
            //{
            //    _categoriesRepository.AddCategory(category);
            //    LoadData();
            //}
            //else
            //{
            //    _messageBoxService.Show("Name and Description is not empty");
            //}

        }

        private bool CanReload(object obj)
        {
            return true;
        }

        private void Reload(object obj)
        {
            CurrentCategory = new Category();
        }

    }
}
