namespace MB.Application.Contracts.Comment;

public interface ICommentApplication
{
    void Add(AddComment command);
    List<CommentViewModel> GetAll();
    void Confirm(long id);
    void Cancel(long id);
}