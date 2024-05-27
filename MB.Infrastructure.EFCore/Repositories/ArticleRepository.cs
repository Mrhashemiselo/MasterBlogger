using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository(MasterBloggerContext dbContext) : IArticleRepository
    {
        public void CreateAndSave(Article entity)
        {
            dbContext.Articles.Add(entity);
            Save();
        }

        public bool Exist(string title)
        {
            return dbContext.Articles
                .Any(a => a.Title == title);
        }

        public Article GetArticle(long id)
        {
            return dbContext.Articles
                .FirstOrDefault(a => a.Id == id);
        }

        public List<ArticleViewModel> GetList()
        {
            return dbContext.Articles
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

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
