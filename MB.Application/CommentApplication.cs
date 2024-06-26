﻿using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application;

public class CommentApplication(ICommentRepository commentRepository) : ICommentApplication
{
    private readonly ICommentRepository _commentRepository = commentRepository;

    public void Add(AddComment command)
    {
        var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
        _commentRepository.Create(comment);
    }

    public void Cancel(long id)
    {
        var comment = _commentRepository.Get(id);
        comment.Cancel();
      //  _commentRepository.Save();
    }

    public void Confirm(long id)
    {
        var comment = _commentRepository.Get(id);
        comment.Confirm();
    //    _commentRepository.Save();
    }

    public List<CommentViewModel> GetList()
    {
        return _commentRepository.GetList();
    }
}