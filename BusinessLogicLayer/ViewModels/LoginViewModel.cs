using BusinessLogicLayer.Command;
using DataAccessLayer.Models;
using DataAccessLayer.Repository.Interface;
using DataAccessLayer.Repository.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BusinessLogicLayer.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private SystemAccount _systemAccount;
        private readonly IWindowService _windowService;
        private readonly IMessageBoxService _messageBoxService;
        public ISystemAccountRepository _systemAccountRepository;
        public SystemAccount CurrentSystemAccount
        {
            get { return _systemAccount; }
            set { _systemAccount = value; OnPropertyChanged(); }
        }

        public ICommand SignInCommand { get; set; }
        public LoginViewModel(IMessageBoxService messageBoxService, IWindowService windowService) 
        {
            _systemAccountRepository = new SystemAccountService();
            CurrentSystemAccount = new SystemAccount();
            SignInCommand = new RelayCommand(SignInUserCommand, CanSignIn);
            _messageBoxService = messageBoxService;
            _windowService = windowService;
        }

        private bool CanSignIn(object obj)
        {
            return true;
        }

        private void SignInUserCommand(object obj)
        {
            SystemAccount sa = CurrentSystemAccount;

            string adminUser = _windowService.EmailAdmin();
            string adminPassword = _windowService.PasswordAdmin();

            if (adminUser == sa.AccountEmail && adminPassword == sa.AccountPassword)
            {
                _windowService.CloseWindow(obj);
                _windowService.OpenManageAccountAdmin();
                return;
            }
            if (string.IsNullOrEmpty(sa.AccountEmail) == true)
            {
                _messageBoxService.Show("Please input email!");
            }
            else if(string.IsNullOrEmpty(sa.AccountPassword) == true)
            {
                _messageBoxService.Show("Please input password!");
            }
            else
            {
                var account = _systemAccountRepository.GetAllSystemAccount().Where(a => a.AccountEmail == sa.AccountEmail.Trim() && a.AccountPassword == sa.AccountPassword.Trim()).FirstOrDefault();
                if (account == null)
                {
                    _messageBoxService.Show("Email or Password invalid!");
                }
                else
                {
                    if(account.AccountRole == 1)
                    {
                        _windowService.CloseWindow(obj);
                        _windowService.OpenStaffWindow(account);
                       
                        return;

                    }
                    else
                    {
                        _messageBoxService.Show("you are not allowed to access");
                    }
                }
            }
        }
    }
}
