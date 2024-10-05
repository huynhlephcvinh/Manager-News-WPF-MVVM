using BusinessLogicLayer.ViewModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HuynhLePhucVinhWPF.Views.Admin
{
    /// <summary>
    /// Interaction logic for InsertOrUpdateAccount.xaml
    /// </summary>
    public partial class InsertOrUpdateAccount : Window
    {
        public InsertOrUpdateAccount(SystemAccount? account = null)
        {
            InitializeComponent();
            InsertOrUpdateSystemAccountViewModel viewModel = new InsertOrUpdateSystemAccountViewModel(new WindowService(), new MessageBoxService(), account);
            this.DataContext = viewModel;
            var VM = (InsertOrUpdateSystemAccountViewModel)DataContext;
            if (VM.CloseAction == null)
            {
                VM.CloseAction = new Action(() => this.DialogResult = true);
                //VM.CloseAction = new Action(this.Close);
            }

        }
    }
}
