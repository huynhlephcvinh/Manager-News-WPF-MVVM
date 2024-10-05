using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Manager
{
    public class SystemAccountManager
    {
        //using singleton pattern
        private static SystemAccountManager instance = null;
        public static readonly object instanceLock = new object();
        private SystemAccountManager() { }
        public static SystemAccountManager Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SystemAccountManager();
                    }
                    return instance;
                }
            }
        }
        //------------------------------------------

        public List<SystemAccount> GetAllSystemAccount()
        {
            List<SystemAccount> list = new List<SystemAccount>();
            using (var context = new FunewsManagementDbContext())
            {
                list = context.SystemAccounts.ToList();
            }
            return list;
        }

        public SystemAccount GetSystemAccount(short id)
        {
            SystemAccount sa = new SystemAccount();
            using (var context = new FunewsManagementDbContext())
            {
                sa = context.SystemAccounts.FirstOrDefault(x => x.AccountId == id);

            }
            return sa;
        }

        public void UpdaterAccount(SystemAccount sa)
        {
            try
            {
                using (var context = new FunewsManagementDbContext())
                {
                    SystemAccount oldSa = context.SystemAccounts.FirstOrDefault(x => x.AccountId == sa.AccountId);
                    if (oldSa != null)
                    {
                        oldSa.AccountName = sa.AccountName;
                        oldSa.AccountEmail = sa.AccountEmail;
                        oldSa.AccountPassword = sa.AccountPassword;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdaterAccount2(SystemAccount sa)
        {
            try
            {
                using (var context = new FunewsManagementDbContext())
                {
                    SystemAccount oldSa = context.SystemAccounts.FirstOrDefault(x => x.AccountId == sa.AccountId);
                    if (oldSa != null)
                    {
                        oldSa.AccountName = sa.AccountName;
                        oldSa.AccountEmail = sa.AccountEmail;
                        oldSa.AccountRole = sa.AccountRole;
                        oldSa.AccountPassword = sa.AccountPassword;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddAccount(SystemAccount sa)
        {
            try
            {
                using (var context = new FunewsManagementDbContext())
                {
                    var lastItem = context.SystemAccounts.OrderByDescending(t => t.AccountId).FirstOrDefault();
                    if (lastItem != null)
                    {
                        sa.AccountId = (short)(lastItem.AccountId + 1);
                        context.SystemAccounts.Add(sa);
                        context.SaveChanges();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoveAccount(short id)
        {
            try
            {
                using (var context = new FunewsManagementDbContext())
                {
                   var listNews = context.NewsArticles.Where(x => x.CreatedById == id).ToList();
                    if (listNews.Count > 0)
                    {
                        foreach (var news in listNews)
                        {
                            news.CategoryId = null;
                        }
                    }

                    var accountRemove = context.SystemAccounts.FirstOrDefault(x=> x.AccountId == id);
                    context.SystemAccounts.Remove(accountRemove);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
