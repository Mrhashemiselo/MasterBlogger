using MB.Application.Contracts.Comment;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class ArticleDetailsModel(IArticleQuery articleQuery
        , ICommentApplication commentApplication) : PageModel
    {
        public ArticleQueryView Article { get; set; }
        
        private readonly IArticleQuery _articleQuery = articleQuery;
        private readonly ICommentApplication _commentApplication = commentApplication;



        public void OnGet(long id)
        {
            Article = _articleQuery.GetArticle(id);
        }

        public RedirectToPageResult OnPost(AddComment command) 
        {
            _commentApplication.Add(command);
            return RedirectToPage("./ArticleDetails", new { id = command.ArticleId});
        }
    }
}