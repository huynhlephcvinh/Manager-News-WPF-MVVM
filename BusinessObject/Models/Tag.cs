using BusinessLogicLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DataAccessLayer.Models;

public partial class Tag : BaseViewModel
{

    private int _id;
    private string _name;
    private string _note;

    public Tag() {
        NewsArticles = new HashSet<NewsArticle>();
    }
    public int TagId
    {
        get { return _id; }
        set { _id = value; OnPropertyChanged(); }
    }

    public string? TagName
    {
        get { return _name; }
        set { _name = value; OnPropertyChanged(); }
    }

    public string? Note
    {
        get { return _note; }
        set { _note = value; OnPropertyChanged(); }
    }

    public virtual ICollection<NewsArticle> NewsArticles { get; } = new List<NewsArticle>();
}
