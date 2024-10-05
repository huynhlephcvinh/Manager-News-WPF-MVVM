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
    public class InsertOrUpdateSystemAccountViewModel : BaseViewModel
    {

        public ISystemAccountRepository _systemAccountRepository;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IWindowService _windowService;
        public Action CloseAction { get; set; }
        private SystemAccount _account;
        public SystemAccount CurrentAccount
        {
            get { return _account; }
            set { _account = value; OnPropertyChanged(); }
        }

        public ICommand AddAccountCommand { get; set; }
        public ICommand CloseAccountCommand { get; set; }
        public ICommand UpdateAccountCommand { get; set; }

        public InsertOrUpdateSystemAccountViewModel(IWindowService windowService, IMessageBoxService messageBoxService, SystemAccount? sa = null)
        {
            _systemAccountRepository = new SystemAccountService();
            _messageBoxService = messageBoxService;
            _windowService = windowService;
            if (sa == null) { CurrentAccount = new SystemAccount(); }
            else { CurrentAccount = sa; }
            AddAccountCommand = new RelayCommand(AddAccount, CanAddAccount);
            UpdateAccountCommand = new RelayCommand(UpdateAccount, CanUpdateAccount);
            CloseAccountCommand = new RelayCommand(CloseAccount, CanCloseAccount);
        }

        private bool CanCloseAccount(object obj)
        {
            return true;
        }

        private void CloseAccount(object obj)
        {
            _windowService.CloseWindow(obj);
        }

        private bool CanUpdateAccount(object obj)
        {
            return true;
        }

        private void UpdateAccount(object obj)
        {
            SystemAccount CurrentUser = CurrentAccount;
            if (string.IsNullOrEmpty(CurrentUser.AccountName) == false && string.IsNullOrEmpty(CurrentUser.AccountEmail) == false && string.IsNullOrEmpty(CurrentUser.AccountPassword) == false && string.IsNullOrEmpty(CurrentUser.AccountRole.ToString()) == false)
            {
                _systemAccountRepository.UpdaterAccount2(CurrentUser);
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

        private bool CanAddAccount(object obj)
        {
            return true;
        }

        private void AddAccount(object obj)
        {
            SystemAccount CurrentUser = CurrentAccount;
            if (string.IsNullOrEmpty(CurrentUser.AccountName) == false && string.IsNullOrEmpty(CurrentUser.AccountEmail) == false && string.IsNullOrEmpty(CurrentUser.AccountPassword) == false && string.IsNullOrEmpty(CurrentUser.AccountRole.ToString()) == false)
            {
                _systemAccountRepository.AddAccount(CurrentUser);
                if (CloseAction != null)
                {
                    CloseAction();

                }
                //CloseAction?.Invoke();
                //_windowService.CloseWindow(obj);
            }
            else
            {
                _messageBoxService.Show("Name and Email or Password is not empty");
            }
        }
    }
}
