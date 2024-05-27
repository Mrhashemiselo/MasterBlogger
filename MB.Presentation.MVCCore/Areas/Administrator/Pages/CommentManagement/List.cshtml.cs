using MB.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.CommentManagement
{
    public class ListModel(ICommentApplication commentApplication) : PageModel
    {
        private readonly ICommentApplication _commentApplication = commentApplication;
        public List<CommentViewModel> Comments { get; set; }
        public void OnGet()
        {
            Comments = _commentApplication.GetList();
        }
        public RedirectToPageResult OnPostConfirm(long id)
        {
            _commentApplication.Confirm(id);
            return RedirectToPage("./List");
        }
        public RedirectToPageResult OnPostCancel(long id)
        {
            _commentApplication.Cancel(id);
            return RedirectToPage("./List");
        }
    }
}
