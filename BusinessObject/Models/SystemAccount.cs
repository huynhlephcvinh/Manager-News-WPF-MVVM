using BusinessLogicLayer.ViewModels;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class SystemAccount : BaseViewModel
{
    private short _id;
    private string _name;
    private string _email;
    private int? _role;
    private string _password;

    public SystemAccount() 
    {
        NewsArticles = new HashSet<NewsArticle>();
    }

    public short AccountId
    {
        get { return _id; }
        set { _id = value; OnPropertyChanged(); }
    }

    public string? AccountName
    {
        get { return _name; }
        set { _name = value; OnPropertyChanged(); }
    }

    public string? AccountEmail
    {
        get { return _email; }
        set { _email = value; OnPropertyChanged(); }
    }

    public int? AccountRole
    {
        get { return _role; }
        set { _role = value; OnPropertyChanged(); }
    }

    public string? AccountPassword
    {
        get { return _password; }
        set { _password = value; OnPropertyChanged(); }
    }

    public virtual ICollection<NewsArticle> NewsArticles { get; } = new List<NewsArticle>();
}
