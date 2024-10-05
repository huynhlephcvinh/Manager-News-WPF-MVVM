using BusinessLogicLayer.Command;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BusinessLogicLayer.ViewModels
{
    public class StaffViewModel : BaseViewModel
    {
        private SystemAccount _systemAccount;
        private readonly IWindowService _windowService;

        public SystemAccount SystemAccount
        {
            get { return _systemAccount; }
            set { _systemAccount = value; OnPropertyChanged(); }
        }
        public ICommand ToPage1Command { get; set; }
        public ICommand ToPage2Command { get; set; }
        public ICommand ToPage3Command { get; set; }
        public ICommand ToPage4Command { get; set; }


        public StaffViewModel(IWindowService windowService, SystemAccount sa) 
        {
            _windowService = windowService;
            ToPage1Command = new RelayCommand(ToPage1, CanToPage1);
            ToPage2Command = new RelayCommand(ToPage2, CanToPage2);
            ToPage3Command = new RelayCommand(ToPage3, CanToPage3);
            ToPage4Command = new RelayCommand(ToPage4, CanToPage4);
            SystemAccount = sa;
        }

        private bool CanToPage4(object obj)
        {
            return true;
        }

        private void ToPage4(object obj)
        {
            _windowService.DirectPage4(obj, SystemAccount);
        }

        private bool CanToPage3(object obj)
        {
            return true;
        }

        private void ToPage3(object obj)
        {
            _windowService.DirectPage3(obj);
        }

        private bool CanToPage2(object obj)
        {
            return true;
        }

        private void ToPage2(object obj)
        {
            _windowService.DirectPage2(obj, SystemAccount);
        }

        private bool CanToPage1(object obj)
        {
            return true;
        }

        private void ToPage1(object obj)
        {
            _windowService.DirectPage1(obj);
        }
    }
}
