using BusinessLogicLayer;
using DataAccessLayer.Models;
using HuynhLePhucVinhWPF.Views.Admin;
using HuynhLePhucVinhWPF.Views.Staff;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace HuynhLePhucVinhWPF
{
    public class WindowService : IWindowService
    {

        public void OpenMainWindow()
        {                
                MainWindow window = new MainWindow();
                window.Show();

        }
        public void OpenManageAccountAdmin()
        {
            ManageAccount manageAccount = new ManageAccount();
            manageAccount.Show();
        }


        public void CloseWindow(object window)
        {
            if (window is Window win)
            {
                win.Close();
            }
        }


        public bool InsertOrUpdateCategory(bool insertorupdate, Category? category = null)
        {
            if (insertorupdate)
            {
                InsertOrUpdateCategory insertOrUpdateCategory = new InsertOrUpdateCategory();
                insertOrUpdateCategory.titleLabel.Content = "Add Category";
                insertOrUpdateCategory.btOK.Content = "Add";
                insertOrUpdateCategory.btUpdate.Visibility = Visibility.Collapsed;

                bool? result = insertOrUpdateCategory.ShowDialog();
                if (result == true)
                {
                   return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                InsertOrUpdateCategory insertOrUpdateCategory = new InsertOrUpdateCategory(category);
                insertOrUpdateCategory.titleLabel.Content = "Update Category";
                insertOrUpdateCategory.btUpdate.Content = "Update";
                insertOrUpdateCategory.btOK.Visibility = Visibility.Collapsed;
                bool? result = insertOrUpdateCategory.ShowDialog();
                if (result == true)
                {
                   return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool InsertOrUpdateTag(bool insertorupdate, Tag? tag = null)
        {
            if (insertorupdate)
            {
                InsertOrUpdateTag insertOrUpdateTag = new InsertOrUpdateTag();
                insertOrUpdateTag.titleLabel.Content = "Add Tag";
                insertOrUpdateTag.btOK.Content = "Add";
                insertOrUpdateTag.btUpdate.Visibility = Visibility.Collapsed;

                bool? result = insertOrUpdateTag.ShowDialog();
                if (result == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                InsertOrUpdateTag insertOrUpdateTag = new InsertOrUpdateTag(tag);
                insertOrUpdateTag.titleLabel.Content = "Update Tag";
                insertOrUpdateTag.btUpdate.Content = "Update";
                insertOrUpdateTag.btOK.Visibility = Visibility.Collapsed;
                bool? result = insertOrUpdateTag.ShowDialog();
                if (result == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool InsertOrUpdateNews(bool insertorupdate, SystemAccount? sa = null, NewsArticle? news = null)
        {
            if (insertorupdate)
            {
                InsertOrUpdateNews insertOrUpdateNews = new InsertOrUpdateNews(sa);
                insertOrUpdateNews.titleLabel.Content = "Add News";
                insertOrUpdateNews.btOK.Content = "Add";
                insertOrUpdateNews.btUpdate.Visibility = Visibility.Collapsed;

                bool? result = insertOrUpdateNews.ShowDialog();
                if (result == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                InsertOrUpdateNews insertOrUpdateNews = new InsertOrUpdateNews(sa, news);
                insertOrUpdateNews.titleLabel.Content = "Update News";
                insertOrUpdateNews.btUpdate.Content = "Update";
                insertOrUpdateNews.btOK.Visibility = Visibility.Collapsed;
                bool? result = insertOrUpdateNews.ShowDialog();
                if (result == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool InsertOrUpdateAccount(bool insertorupdate, SystemAccount? account = null)
        {
            if (insertorupdate)
            {
                InsertOrUpdateAccount insertOrUpdateAccount = new InsertOrUpdateAccount();
                insertOrUpdateAccount.titleLabel.Content = "Add Account";
                insertOrUpdateAccount.btOK.Content = "Add";
                insertOrUpdateAccount.btUpdate.Visibility = Visibility.Collapsed;

                bool? result = insertOrUpdateAccount.ShowDialog();
                if (result == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                InsertOrUpdateAccount insertOrUpdateAccount = new InsertOrUpdateAccount(account);
                insertOrUpdateAccount.titleLabel.Content = "Update Account";
                insertOrUpdateAccount.btUpdate.Content = "Update";
                insertOrUpdateAccount.btOK.Visibility = Visibility.Collapsed;
                bool? result = insertOrUpdateAccount.ShowDialog();
                if (result == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public void DirectPage1(object window)
        {
            if (window is frmStaff win)
            {
                win.frMain.Content = new CategoryPage1();
            }
        }

        public void DirectPage2(object window, SystemAccount sa)
        {
            if (window is frmStaff win)
            {
                win.frMain.Content = new NewsArticlePage2(sa);
            }
        }
        public void DirectPage3(object window)
        {
            if (window is frmStaff win)
            {
                win.frMain.Content = new TagPage3();
            }
        }

        public void DirectPage4(object window, SystemAccount sa)
        {
            if (window is frmStaff win)
            {
                win.frMain.Content = new ProfilePage4(sa);
            }
        }


        public void OpenLoginWindow()
        {
           
          frmLogin frmlogin = new frmLogin();
          frmlogin.Show();
             
        }



        public void OpenStaffWindow(SystemAccount sa)
        {
  
                frmStaff frmStaff = new frmStaff(sa);
                frmStaff.Show();
        }
        public void OpenNewsReport()
        {

            ReportStatisticNews reportStatisticNews = new ReportStatisticNews();
            reportStatisticNews.Show();
        }

        public string EmailAdmin()
        {
            IConfiguration config = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", true, true)
                      .Build();
            var adminUser = config["AdminAccount:Email"];
            return adminUser;
        }
        public string PasswordAdmin()
        {
            IConfiguration config = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", true, true)
                      .Build();
            var adminPassword = config["AdminAccount:Password"];
            return adminPassword;
        }




    }
}
