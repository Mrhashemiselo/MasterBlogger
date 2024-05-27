using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoryRepository(MasterBloggerContext dbContext) : IArticleCategoryRepository
    {
        public void Add(ArticleCategory entity)
        {
            dbContext.ArticleCategories.Add(entity);
            Save();
        }

        public bool Exist(string title)
        {
            return dbContext.ArticleCategories.Any(a=> a.Title == title);
        }

        public List<ArticleCategory> GetAll()
        {
            return dbContext.ArticleCategories.ToList();
        }

        public ArticleCategory GetById(long id)
        {
            return dbContext.ArticleCategories.FirstOrDefault(a => a.Id == id);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
