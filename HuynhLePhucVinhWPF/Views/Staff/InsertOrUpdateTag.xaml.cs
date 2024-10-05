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
    /// Interaction logic for InsertOrUpdateTag.xaml
    /// </summary>
    public partial class InsertOrUpdateTag : Window
    {
        public InsertOrUpdateTag(Tag? newTag = null)
        {
            InitializeComponent();
            InsertOrUpdateTagViewModel tag = new InsertOrUpdateTagViewModel(new WindowService(), new MessageBoxService(), newTag);
            this.DataContext = tag;
            var VM = (InsertOrUpdateTagViewModel)DataContext;
            if (VM.CloseAction == null)
            {
                VM.CloseAction = new Action(() => this.DialogResult = true);
                //VM.CloseAction = new Action(this.Close);
            }
        }
    }
}
