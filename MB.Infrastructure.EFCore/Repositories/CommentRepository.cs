using _01_Framework.Infrastructure;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MB.Infrastructure.EFCore.Repositories;

public class CommentRepository(MasterBloggerContext dbContext) : BaseRepository<long, Comment>(dbContext), ICommentRepository
{
    private readonly MasterBloggerContext _dbContext = dbContext;

    public List<CommentViewModel> GetList()
    {
        return _dbContext.Comments
            .Include(a => a.Article)
            .Select(s => new CommentViewModel()
            {
                Id = s.Id,
                Article = s.Article.Title,
                CreationDate = s.CreationDate.ToString(CultureInfo.InvariantCulture),
                Email = s.Email,
                Message = s.Message,
                Name = s.Name,
                Status = s.Status,
            }).ToList();
    }
}