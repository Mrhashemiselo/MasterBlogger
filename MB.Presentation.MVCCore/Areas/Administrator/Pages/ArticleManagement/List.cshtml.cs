using MB.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class ListModel(IArticleApplication articleApplication) : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }

        public void OnGet()
        {
            Articles = articleApplication.GetList();
        }

        public RedirectToPageResult OnPostActivate(long id)
        {
            articleApplication.Activate(id);
            return RedirectToPage("./list");
        }

        public RedirectToPageResult OnPostRemove(long id)
        {
            articleApplication.Remove(id);
            return RedirectToPage("./list");
        }
    }
}
