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
    /// Interaction logic for NewsArticlePage2.xaml
    /// </summary>
    public partial class NewsArticlePage2 : Page
    {
        public NewsArticlePage2(SystemAccount sa)
        {
            InitializeComponent();
            ManageNewsArticleViewModel manageNewsArticleViewModel = new ManageNewsArticleViewModel(new WindowService(), new MessageBoxService(),sa);
            this.DataContext = manageNewsArticleViewModel;


        }
    }
}
