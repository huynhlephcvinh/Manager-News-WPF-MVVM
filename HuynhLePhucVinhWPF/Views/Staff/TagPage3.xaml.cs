using BusinessLogicLayer.ViewModels;
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
    /// Interaction logic for TagPage3.xaml
    /// </summary>
    public partial class TagPage3 : Page
    {
        public TagPage3()
        {
            InitializeComponent();
            ManageTagViewModel manageTagViewModel = new ManageTagViewModel(new WindowService(), new MessageBoxService());
            this.DataContext = manageTagViewModel;
        }
    }
}
