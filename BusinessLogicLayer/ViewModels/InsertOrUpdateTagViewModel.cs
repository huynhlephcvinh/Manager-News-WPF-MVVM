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
    public class InsertOrUpdateTagViewModel : BaseViewModel
    {
        public ITagRepository _tagRepository;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IWindowService _windowService;
        public Action CloseAction { get; set; }
        private Tag _tag;
        public Tag CurrentTag
        {
            get { return _tag; }
            set { _tag = value; OnPropertyChanged(); }
        }
        public ICommand AddTagCommand { get; set; }
        public ICommand UpdateTagCommand { get; set; }
        public ICommand CloseTagCommand { get; set; }   


        public InsertOrUpdateTagViewModel(IWindowService windowService, IMessageBoxService messageBoxService, Tag? newtag = null)
        {
            _tagRepository = new TagService();
            _messageBoxService = messageBoxService;
            _windowService = windowService;
            if(newtag != null)
            {
                CurrentTag = newtag;
            }
            else
            {
                CurrentTag = new Tag();
            }
            AddTagCommand = new RelayCommand(AddTag, CanAddTag);
            UpdateTagCommand = new RelayCommand(UpdateTag, CanUpdateTag);
            CloseTagCommand = new RelayCommand(CloseTag, CanCloseTag);
        }

        private bool CanCloseTag(object obj)
        {
            return true;
        }

        private void CloseTag(object obj)
        {
            _windowService.CloseWindow(obj);
        }

        private bool CanUpdateTag(object obj)
        {
            return true;
        }

        private void UpdateTag(object obj)
        {

            Tag tag = CurrentTag;
            if (string.IsNullOrEmpty(tag.TagName) == false && string.IsNullOrEmpty(tag.Note) == false)
            {
                _tagRepository.UpdateTag(tag);
                if (CloseAction != null)
                {
                    CloseAction();

                }

            }
            else
            {
                _messageBoxService.Show("Name and Note is not empty");
            }
        }

        private bool CanAddTag(object obj)
        {
            return true;
        }

        private void AddTag(object obj)
        {
            Tag tag = CurrentTag;
            if (string.IsNullOrEmpty(tag.TagName) == false && string.IsNullOrEmpty(tag.Note) == false)
            {
                _tagRepository.AddTag(tag);
                if (CloseAction != null)
                {
                    CloseAction();

                }
                //CloseAction?.Invoke();
                //_windowService.CloseWindow(obj);
            }
            else
            {
                _messageBoxService.Show("Name and Note is not empty");
            }
        }
    }
}
