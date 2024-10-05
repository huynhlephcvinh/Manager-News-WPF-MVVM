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
    /// Interaction logic for InsertOrUpdateCategory.xaml
    /// </summary>
    public partial class InsertOrUpdateCategory : Window
    {
        public InsertOrUpdateCategory(Category? category = null)
        {
            InitializeComponent();
            InsertOrUpdateCategoryViewModel viewModel = new InsertOrUpdateCategoryViewModel(new WindowService(), new MessageBoxService(), category);
            this.DataContext = viewModel;
            var VM = (InsertOrUpdateCategoryViewModel)DataContext;
            if (VM.CloseAction == null)
            {
                VM.CloseAction = new Action(() => this.DialogResult = true);
                //VM.CloseAction = new Action(this.Close);
            }
        }

        }
    }

