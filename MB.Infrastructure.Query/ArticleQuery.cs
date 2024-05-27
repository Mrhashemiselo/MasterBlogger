using System.Globalization;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query;

public class ArticleQuery(MasterBloggerContext dbContext) : IArticleQuery
{
    public List<ArticleQueryView> GetArticles()
    {
        return dbContext.Articles
            .Include(a => a.ArticleCategory)
            .Include(s => s.Comments)
            .Select(x =>
            new ArticleQueryView()
            {
                Id = x.Id,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString("yyyy/MM/dd"),
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Image = x.Image,
                CommentsCount = x.Comments.Count(w => w.Status == (int)Statuses.Confirmed)
            })
            .ToList();
    }

    public ArticleQueryView? GetArticle(long id)
    {
        return dbContext.Articles
            .Include(a => a.ArticleCategory)
            .Select(x =>
                new ArticleQueryView()
                {
                    Id = x.Id,
                    ArticleCategory = x.ArticleCategory.Title,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    Image = x.Image,
                    Content = x.Content,
                    CommentsCount = x.Comments.Count(w => w.Status == (int)Statuses.Confirmed),
                    Comments = MapComments(x.Comments.Where(q => q.Status == (int)Statuses.Confirmed))
                })
            .FirstOrDefault(a => a.Id == id);
    }

    private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
    {
        return comments
            .Select(s => new CommentQueryView()
            {
                Name = s.Name,
                Message = s.Message,
                CreationDate = s.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).ToList();
    }
}
