using BusinessLogicLayer.ViewModels;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class NewsArticle : BaseViewModel
{ 
    private string _id;
    private string? _title;
    private DateTime? _createdDate;
    private string? _newContent;
    private short? _categoryId;
    private bool? _newsStatus;
    private short? _createById;
    private DateTime? _modifiedDate;

    public NewsArticle()
    {
        Tags = new HashSet<Tag>();
    }


    public string NewsArticleId
    {
        get { return _id; }
        set { _id = value; OnPropertyChanged(); }
    } 

    public string? NewsTitle
    {
        get { return _title; }
        set { _title = value; OnPropertyChanged(); }
    }

    public DateTime? CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; OnPropertyChanged(); }
    }

    public string? NewsContent
    {
        get { return _newContent; }
        set { _newContent = value; OnPropertyChanged(); }
    }

    public short? CategoryId
    {
        get { return _categoryId; }
        set { _categoryId = value; OnPropertyChanged(); }
    }

    public bool? NewsStatus
    {
        get { return _newsStatus; }
        set { _newsStatus = value; OnPropertyChanged(); }
    }

    public short? CreatedById
    {
        get { return _createById; }
        set { _createById = value; OnPropertyChanged(); }
    }

    public DateTime? ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; OnPropertyChanged(); }
    }

    public virtual Category? Category { get; set; }

    public virtual SystemAccount? CreatedBy { get; set; }

    public virtual ICollection<Tag> Tags { get; } = new List<Tag>();
}
