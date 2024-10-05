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
    public class ManageAccountViewModel : BaseViewModel
    {

        public ISystemAccountRepository _systemAccountRepository;

        private ObservableCollection<SystemAccount> accounts;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IWindowService _windowService;

        private SystemAccount _account;
        public ObservableCollection<SystemAccount> Accounts
        {
            get { return accounts; }
            set { accounts = value; OnPropertyChanged(); }
        }

        public SystemAccount CurrentAccount
        {
            get { return _account; }
            set { _account = value; OnPropertyChanged(); }
        }

        public ICommand ReloadCommand { get; set; }
        public ICommand AddAccountCommand { get; set; }
        public ICommand UpdateAccountCommand { get; set; }
        public ICommand DeteleAccountCommand { get; set; }
        public ICommand ReportNewsCommand { get; set; } 
        private void LoadData()
        {
            Accounts = new ObservableCollection<SystemAccount>(_systemAccountRepository.GetAllSystemAccount());
            CurrentAccount = new SystemAccount();
        }
        public ManageAccountViewModel(IWindowService windowService, IMessageBoxService messageBoxService) 
        {
            _systemAccountRepository = new SystemAccountService();
            LoadData();
            _messageBoxService = messageBoxService;
            _windowService = windowService;
            ReloadCommand = new RelayCommand(Reload, CanReload);
            AddAccountCommand = new RelayCommand(AddAccount, CanAddAccount);
            UpdateAccountCommand = new RelayCommand(UpdateAccount, CanUpdateAccount);
            DeteleAccountCommand = new RelayCommand(DeleteAccount, CanDeleteAccount);
            ReportNewsCommand = new RelayCommand(ReportNews, CanReportNews);
        }

        private bool CanReportNews(object obj)
        {
            return true;
        }

        private void ReportNews(object obj)
        {
            _windowService.OpenNewsReport();
        }

        private bool CanDeleteAccount(object obj)
        {
            return true;
        }

        private void DeleteAccount(object obj)
        {
            try
            {
                if (_messageBoxService.ShowMessageBoxYesNo() == 1)
                {
                    short id = CurrentAccount.AccountId;
                    _systemAccountRepository.RemoveAccount(id);
                    LoadData();
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

        private bool CanUpdateAccount(object obj)
        {
            return true;

        }

        private void UpdateAccount(object obj)
        {
            SystemAccount sa = CurrentAccount;
            if (string.IsNullOrEmpty(sa.AccountName) == true && string.IsNullOrEmpty(sa.AccountPassword) == true)

            {
                _messageBoxService.Show("You must choose one account to update");
                return;
            }
            else
            {
                if (_windowService.InsertOrUpdateAccount(false, sa) == true)
                {
                    LoadData();
                }
            }
        }

        private bool CanAddAccount(object obj)
        {
            return true;
        }

        private void AddAccount(object obj)
        {
            if (_windowService.InsertOrUpdateAccount(true) == true)
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
            CurrentAccount = new SystemAccount();
        }
    }
}
