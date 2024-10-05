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

namespace HuynhLePhucVinhWPF
{
    /// <summary>
    /// Interaction logic for frmStaff.xaml
    /// </summary>
    public partial class frmStaff : Window
    {
        public frmStaff(SystemAccount sa)
        {
            InitializeComponent();
            StaffViewModel viewModel = new StaffViewModel(new WindowService(), sa);
            this.DataContext = viewModel;
        }
    }
}
