﻿using _01_Framework.Domain;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg;
public class ArticleCategory : DomainBase<long>
{
    public string Title { get; private set; }
    public bool IsDeleted { get; private set; }
    public ICollection<Article> Articles { get; set; }

    protected ArticleCategory()
    {
        
    }

    public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
    {
        validatorService.RecordAlreadyExist(title);
        Title = title;
        IsDeleted = false;
        Articles = new List<Article>();
    }

    public void Rename(string title)
    {
        GuardAgainstEmptyTitle(title);
        Title = title;
    }

    public void Remove()
    {
        IsDeleted = true;
    }
    
    public void Activate()
    {
        IsDeleted = false;
    }

    public void GuardAgainstEmptyTitle(string title)
    {
        if(string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException("title");
    }
}
