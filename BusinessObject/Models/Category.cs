using BusinessLogicLayer.ViewModels;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Category : BaseViewModel
{
    private short _id;
    private string _name;
    private string _description;

    public Category() 
    {
        NewsArticles = new HashSet<NewsArticle>();
    }

    public short CategoryId
    {
        get { return _id; }
        set { _id = value; OnPropertyChanged(); }
    }

    public string CategoryName
    {
        get { return _name; }
        set { _name = value; OnPropertyChanged(); }
    }

    public string CategoryDesciption
    {
        get { return _description; }
        set { _description = value; OnPropertyChanged(); }
    }

    public virtual ICollection<NewsArticle> NewsArticles { get; } = new List<NewsArticle>();
}
