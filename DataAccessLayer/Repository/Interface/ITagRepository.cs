using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Interface
{
    public interface ITagRepository
    {
        public Tag GetTag(int id);
        public List<Tag> GetAllTag();
        public void AddTag(Tag tag);
        public void UpdateTag(Tag newtag);
        public void DeleteTag(int id);
    }
}
