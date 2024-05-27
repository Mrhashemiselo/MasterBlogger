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
       var articleCategory = articleCategoryRepository.GetById(id);
        articleCategory.Activate();
        articleCategoryRepository.Save();
    }

    public void Create(CreateArticleCategory command)
    {
        var articleCategory = new ArticleCategory(command.Title,articleCategoryValidatorService);
        articleCategoryRepository.Add(articleCategory);
    }

    public RenameArticleCategory GetById(long id)
    {
        var articleCategory = articleCategoryRepository.GetById(id);
        return new RenameArticleCategory()
        {
            Id = articleCategory.Id,
            Title = articleCategory.Title
        };
    }

    public List<ArticleCategoryViewModel> List()
    {
        var articleCategories = articleCategoryRepository.GetAll();
        var result = new List<ArticleCategoryViewModel>();
        foreach (var articleCategory in articleCategories)
        {
            result.Add(new ArticleCategoryViewModel()
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title,
                CreationDate = articleCategory.CreationDate.ToString(CultureInfo.InvariantCulture),
                IsDeleted = articleCategory.IsDeleted
            });
        }
        return result;
    }

    public void Remove(long id)
    {
        var articleCategory = articleCategoryRepository.GetById(id);
        articleCategory.Remove();
        articleCategoryRepository.Save();
    }

    public void Rename(RenameArticleCategory command)
    {
        var articleCategory = articleCategoryRepository.GetById(command.Id);
        articleCategory.Rename(command.Title);
        articleCategoryRepository.Save();
    }
}