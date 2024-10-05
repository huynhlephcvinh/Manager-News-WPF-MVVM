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
    public class TagService : ITagRepository
    {
        public Tag GetTag(int id) => TagManager.Instance.GetTag(id);

        public List<Tag> GetAllTag() => TagManager.Instance.GetAllTag();
        public void AddTag(Tag tag) => TagManager.Instance.AddTag(tag);
        public void UpdateTag(Tag newtag) => TagManager.Instance.UpdateTag(newtag);
        public void DeleteTag(int id) => TagManager.Instance.DeleteTag(id);
    }
}
