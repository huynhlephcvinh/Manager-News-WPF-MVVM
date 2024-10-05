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
    public class ManageTagViewModel :BaseViewModel
    {
        public ITagRepository _tagRepository;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IWindowService _windowService;
        private Tag _tag;
        private ObservableCollection<Tag> _tags;

        public ObservableCollection<Tag> Tags
        {
            get { return _tags; }
            set { _tags = value; OnPropertyChanged(); }
        }

        public Tag CurrentTag
        {
            get { return _tag; }
            set { _tag = value; OnPropertyChanged(); }
        }
        public ICommand ReloadCommand { get; set; }
        public ICommand AddTagCommand { get; set; }
        public ICommand UpdateTagCommand { get; set; }
        public ICommand DeteleTagCommand { get; set; }
        private void LoadData()
        {
            Tags = new ObservableCollection<Tag>(_tagRepository.GetAllTag());
            CurrentTag = new Tag();
        }

        public ManageTagViewModel(IWindowService windowService, IMessageBoxService messageBoxService)
        {
            _windowService = windowService;
            _messageBoxService = messageBoxService;
            _tagRepository = new TagService();
            LoadData();
            ReloadCommand = new RelayCommand(Reload, CanReload);
            AddTagCommand = new RelayCommand(AddTag, CanAddTag);
            UpdateTagCommand = new RelayCommand(UpdateTag, CanUpdateTag);
            DeteleTagCommand = new RelayCommand(DeleteTag, CanDeleteTag);
        }

        private bool CanDeleteTag(object obj)
        {
            return true;
        }

        private void DeleteTag(object obj)
        {
            try
            {
                if (_messageBoxService.ShowMessageBoxYesNo() == 1)
                {
                    int id = CurrentTag.TagId;
                    _tagRepository.DeleteTag(id);
                    LoadData();
                }
                else
                {
                  return;
                }
           }catch(Exception ex)
            {
                _messageBoxService.ShowError(ex);
            }
        }

        private bool CanUpdateTag(object obj)
        {
            return true;
        }

        private void UpdateTag(object obj)
        {
            if (string.IsNullOrEmpty(CurrentTag.TagName) == true && string.IsNullOrEmpty(CurrentTag.Note) == true)

            {
                _messageBoxService.Show("You must choose one tag to update");
                return;
            }
            else
            {
                if (_windowService.InsertOrUpdateTag(false, CurrentTag) == true)
                {
                    LoadData();
                }
            }
        }

        private bool CanAddTag(object obj)
        {
            return true;
        }

        private void AddTag(object obj)
        {
            if (_windowService.InsertOrUpdateTag(true))
            {
                LoadData();
            }
        }

        private bool CanReload(object obj)
        {
            return true;
        }

        private void Reload(object obj)
        {
            CurrentTag = new Tag();
        }
    }
}
