using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Interface
{
    public interface ISystemAccountRepository
    {
        public List<SystemAccount> GetAllSystemAccount();
        public SystemAccount GetSystemAccount(short id);
        public void UpdateAccount(SystemAccount sa);
        public void AddAccount(SystemAccount sa);
        public void RemoveAccount(short id);
        public void UpdaterAccount2(SystemAccount sa);
    }
}
