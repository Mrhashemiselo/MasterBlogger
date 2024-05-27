using MB.Application.Contracts.Comment;

namespace MB.Domain.CommentAgg;

public interface ICommentRepository
{
    void CreateAndSave(Comment entity);
    List<CommentViewModel> GetAll();
    Comment Get(long id);
    void Save();
}