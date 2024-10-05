﻿using BusinessLogicLayer.ViewModels;
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
    /// Interaction logic for ReportStatisticNews.xaml
    /// </summary>
    public partial class ReportStatisticNews : Window
    {
        public ReportStatisticNews()
        {
            InitializeComponent();
            ReportStatisticNewsViewModel reportStatisticNewsViewModel = new ReportStatisticNewsViewModel();
            this.DataContext = reportStatisticNewsViewModel;
        }
    }
}
