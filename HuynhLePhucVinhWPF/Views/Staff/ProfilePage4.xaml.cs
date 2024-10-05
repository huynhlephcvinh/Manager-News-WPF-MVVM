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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HuynhLePhucVinhWPF.Views.Staff
{
    /// <summary>
    /// Interaction logic for ProfilePage4.xaml
    /// </summary>
    public partial class ProfilePage4 : Page
    {
        public ProfilePage4(SystemAccount sa)
        {
            InitializeComponent();
            ManageProfileViewModel manageProfileViewModel = new ManageProfileViewModel(new WindowService(), new MessageBoxService(), sa);
            this.DataContext = manageProfileViewModel;
        }
    }
}
