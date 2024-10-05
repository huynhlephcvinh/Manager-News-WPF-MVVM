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

namespace HuynhLePhucVinhWPF.Views.Staff
{
    /// <summary>
    /// Interaction logic for InsertOrUpdateNews.xaml
    /// </summary>
    public partial class InsertOrUpdateNews : Window
    {
        public InsertOrUpdateNews(SystemAccount? sa =null, NewsArticle? news =null)
        {
            InitializeComponent();
            InsertOrUpdateNewsViewModel insertOrUpdateNewsViewModel = new InsertOrUpdateNewsViewModel(new WindowService(),new MessageBoxService(),sa, news);
            this.DataContext = insertOrUpdateNewsViewModel;
            var VM = (InsertOrUpdateNewsViewModel)DataContext;
            if (VM.CloseAction == null)
            {
                VM.CloseAction = new Action(() => this.DialogResult = true);
                //VM.CloseAction = new Action(this.Close);
            }
        }
    }
}
