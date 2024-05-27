using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using System.Globalization;

namespace MB.Application;

public class ArticleCategoryApplication(
    IArticleCategoryRepository articleCategoryRepository,
    IArticleCategoryValidatorService articleCategoryValidatorService)
    : IArticleCategoryApplication
{
    public void Activate(long id)
    {
       var articleCategory = articleCategoryRepository.Get(id);
        articleCategory.Activate();
        //articleCategoryRepository.Save();
    }

    public void Create(CreateArticleCategory command)
    {
        var articleCategory = new ArticleCategory(command.Title,articleCategoryValidatorService);
        articleCategoryRepository.Create(articleCategory);
    }

    public RenameArticleCategory GetById(long id)
    {
        var articleCategory = articleCategoryRepository.Get(id);
        return new RenameArticleCategory()
        {
            Id = articleCategory.Id,
            Title = articleCategory.Title
        };
    }

    public List<ArticleCategoryViewModel> List()
    {
        var articleCategories = articleCategoryRepository.GetAll();
        return articleCategories
            .Select(a => new ArticleCategoryViewModel()
            {
                Id = a.Id,
                Title = a.Title,
                CreationDate = a.CreationDate.ToString(CultureInfo.InvariantCulture),
                IsDeleted = a.IsDeleted
            }).OrderByDescending(s => s.Id)
            .ToList();
    }

    public void Remove(long id)
    {
        var articleCategory = articleCategoryRepository.Get(id);
        articleCategory.Remove();
        //articleCategoryRepository.Save();
    }

    public void Rename(RenameArticleCategory command)
    {
        var articleCategory = articleCategoryRepository.Get(command.Id);
        articleCategory.Rename(command.Title);
        //articleCategoryRepository.Save();
    }
}