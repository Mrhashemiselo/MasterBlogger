using _01_Framework.Infrastructure;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EFCore.Repositories;

public class ArticleCategoryRepository(MasterBloggerContext dbContext) : BaseRepository<long, ArticleCategory>(dbContext), IArticleCategoryRepository
{
    private readonly MasterBloggerContext _dbContext = dbContext;
}
