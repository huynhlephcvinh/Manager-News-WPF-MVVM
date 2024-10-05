using BusinessLogicLayer.Command;
using DataAccessLayer.Models;
using DataAccessLayer.Repository.Interface;
using DataAccessLayer.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BusinessLogicLayer.ViewModels
{
    public class InsertOrUpdateCategoryViewModel : BaseViewModel
    {

        public ICategoryRepository _categoriesRepository;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IWindowService _windowService;
        public Action CloseAction { get; set; }
        private Category _category;
        public Category CurrentCategory
        {
            get { return _category; }
            set { _category = value; OnPropertyChanged(); }
        }

        public ICommand OKCategoryCommand { get; set; }
        public ICommand CloseCategoryCommand { get; set; }
        public ICommand ChangeCategoryCommand { get; set; }
        public InsertOrUpdateCategoryViewModel(IWindowService windowService,IMessageBoxService messageBoxService, Category? updatecategory =null) 
        {
            _categoriesRepository = new CategoryService();
            if (updatecategory == null) { CurrentCategory = new Category(); }
            else { CurrentCategory = updatecategory; }
           
            _windowService = windowService;
            _messageBoxService = messageBoxService;
            OKCategoryCommand = new RelayCommand(OKCategory, CanOKCategory);
            CloseCategoryCommand = new RelayCommand(CloseCategory, CanCloseCategory);
            ChangeCategoryCommand = new RelayCommand(ChangeCategory, CanChangeCategory);
        }



        private bool CanChangeCategory(object obj)
        {
            return true;
        }

        private void ChangeCategory(object obj)
        {
            Category category = CurrentCategory;
            if (string.IsNullOrEmpty(category.CategoryName) == false && string.IsNullOrEmpty(category.CategoryDesciption) == false)
            {
                _categoriesRepository.UpdateCategory(category);
                if (CloseAction != null)
                {
                    CloseAction();

                }

            }
            else
            {
                _messageBoxService.Show("Name and Description is not empty");
            }
        }

        private bool CanCloseCategory(object obj)
        {
            return true;
        }

        private void CloseCategory(object obj)
        {
            _windowService.CloseWindow(obj);
        }

        private bool CanOKCategory(object obj)
        {
            return true;
        }

        private void OKCategory(object obj)
        {
            Category category = CurrentCategory;
            if (string.IsNullOrEmpty(category.CategoryName) == false && string.IsNullOrEmpty(category.CategoryDesciption) == false)
            {
                _categoriesRepository.AddCategory(category);
                if (CloseAction != null)
                {
                    CloseAction();
                   
                }
                //CloseAction?.Invoke();
                //_windowService.CloseWindow(obj);
            }
            else
            {
                _messageBoxService.Show("Name and Description is not empty");
            }
        }
    }
}
