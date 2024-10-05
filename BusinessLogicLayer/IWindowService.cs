using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IWindowService
    {
        void OpenLoginWindow();

        void OpenStaffWindow(SystemAccount sa);
        void DirectPage2(object window, SystemAccount sa);
        void OpenMainWindow();
        void DirectPage3(object window);
        void CloseWindow(object window);
        void DirectPage1(object window);
        void DirectPage4(object window, SystemAccount sa);
        bool InsertOrUpdateCategory(bool insertorupdate, Category? category = null);
        bool InsertOrUpdateNews(bool insertorupdate, SystemAccount? sa = null, NewsArticle? news = null);
        bool InsertOrUpdateTag(bool insertorupdate, Tag? tag = null);
        bool InsertOrUpdateAccount(bool insertorupdate, SystemAccount? account = null);
        public string EmailAdmin();
        public string PasswordAdmin();
        public void OpenManageAccountAdmin();
        public void OpenNewsReport();
    }
}
