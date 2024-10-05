﻿using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Manager
{
    public class TagManager
    {
        //using singleton pattern
        private static TagManager instance = null;
        public static readonly object instanceLock = new object();
        private TagManager() { }
        public static TagManager Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TagManager();
                    }
                    return instance;
                }
            }
        }
        //------------------------------------------
        public Tag GetTag(int id)
        {
            Tag tag = new Tag();
            using (var context = new FunewsManagementDbContext())
            {
                tag = context.Tags.FirstOrDefault(x => x.TagId == id);


            }
            return tag;
        }

        public List<Tag> GetAllTag()
        {
            List<Tag> list = new List<Tag>();
            using (var context = new FunewsManagementDbContext())
            {
                list = context.Tags.ToList();
            }
            return list;
        }

        public void AddTag(Tag tag)
        {
            try
            {
                using (var context = new FunewsManagementDbContext())
                {
                    var lastItem = context.Tags.OrderByDescending(t => t.TagId).FirstOrDefault();
                    if (lastItem != null)
                    {
                        tag.TagId = lastItem.TagId +1;
                        context.Tags.Add(tag);
                        context.SaveChanges();
                    }
                    else
                    {
                        tag.TagId = 1; 
                        context.Tags.Add(tag);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateTag(Tag newtag)
        {
            try
            {
                using (var context = new FunewsManagementDbContext())
                {
                    Tag oldTag = context.Tags.FirstOrDefault(x => x.TagId == newtag.TagId);
                    if (oldTag != null)
                    {
                        oldTag.TagName = newtag.TagName;
                        oldTag.Note = newtag.Note;
                        context.SaveChanges();
                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteTag(int id)
        {
            try
            {
                using (var context = new FunewsManagementDbContext())
                {
                   var listNews = context.NewsArticles.Include(na => na.Tags).ToList();
                    foreach (var news in listNews)
                    {
                        foreach (var tag in news.Tags)
                        {
                            if(tag.TagId == id)
                            {
                                news.Tags.Remove(tag);

                            }
                        }
                    }
                    var tagRemove = context.Tags.FirstOrDefault(x => x.TagId == id);
                    if (tagRemove != null)
                    {
                        context.Tags.Remove(tagRemove);
                    }
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
