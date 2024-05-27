using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MB.Infrastructure.EFCore.Repositories;

public class CommentRepository(MasterBloggerContext dbContext) : ICommentRepository
{
    private readonly MasterBloggerContext _dbContext = dbContext;

    public void CreateAndSave(Comment entity)
    {
        _dbContext.Comments.Add(entity);
        Save();
    }

    public Comment Get(long id)
    {
        return _dbContext.Comments
            .FirstOrDefault(c => c.Id == id);
    }

    public List<CommentViewModel> GetAll()
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
            }).ToList() ;
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}