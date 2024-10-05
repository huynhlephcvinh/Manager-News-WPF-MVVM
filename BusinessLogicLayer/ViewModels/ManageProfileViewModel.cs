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
    public class ManageProfileViewModel : BaseViewModel
    {
        private readonly IMessageBoxService _messageBoxService;
        private readonly IWindowService _windowService;
        public ISystemAccountRepository _systemAccountRepository;
        private SystemAccount _account;
        public SystemAccount CurrentUser
        {
            get { return _account; }
            set { _account = value; OnPropertyChanged(); }
        }

        public ICommand UpdateUserCommand { get; set; }

        public ManageProfileViewModel(IWindowService windowService, IMessageBoxService messageBoxService, SystemAccount sa)
        {
            _systemAccountRepository = new SystemAccountService();
            _messageBoxService = messageBoxService;
            _windowService = windowService;
            CurrentUser = sa;
            UpdateUserCommand = new RelayCommand(UpdateUser, CanUpdateUser);
        }

        private bool CanUpdateUser(object obj)
        {
            return true;
        }

        private void UpdateUser(object obj)
        {
            if (string.IsNullOrEmpty(CurrentUser.AccountName) == false && string.IsNullOrEmpty(CurrentUser.AccountEmail) == false && string.IsNullOrEmpty(CurrentUser.AccountPassword)==false)
            {
                _systemAccountRepository.UpdateAccount(CurrentUser);
               
            }
            else
            {
                _messageBoxService.Show("Empty");
                return;
            }
        }
    }
}
