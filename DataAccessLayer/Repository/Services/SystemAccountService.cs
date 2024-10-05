using DataAccessLayer.Models;
using DataAccessLayer.Repository.Interface;
using DataAccessLayer.Repository.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Services
{
    public class SystemAccountService : ISystemAccountRepository
    {
        public List<SystemAccount> GetAllSystemAccount() => SystemAccountManager.Instance.GetAllSystemAccount();

        public SystemAccount GetSystemAccount(short id) => SystemAccountManager.Instance.GetSystemAccount(id);

        public void UpdateAccount(SystemAccount sa) => SystemAccountManager.Instance.UpdaterAccount(sa);

        public void AddAccount(SystemAccount sa) => SystemAccountManager.Instance.AddAccount(sa);

        public void RemoveAccount(short id) => SystemAccountManager.Instance.RemoveAccount(id);

        public void UpdaterAccount2(SystemAccount sa) => SystemAccountManager.Instance.UpdaterAccount2(sa);

    }
}
