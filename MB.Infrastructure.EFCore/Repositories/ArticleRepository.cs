using _01_Framework.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MB.Infrastructure.EFCore.Repositories;

public class ArticleRepository(MasterBloggerContext dbContext) : BaseRepository<long,Article>(dbContext) , IArticleRepository
{
    private readonly MasterBloggerContext _dbContext = dbContext;

    public List<ArticleViewModel> GetList()
    {
        return _dbContext.Articles
            .Include(a => a.ArticleCategory)
            .Select(s => new ArticleViewModel()
            {
                Id = s.Id,
                Title = s.Title,
                ArticleCategory = s.ArticleCategory.Title,
                CreationDate = s.CreationDate.ToString(CultureInfo.InvariantCulture),
                IsDeleted = s.IsDeleted
            })
            .ToList();
    }
}
