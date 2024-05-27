using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class ListModel(IArticleCategoryApplication articleCategoryApplication) : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }

        public void OnGet()
        {
            ArticleCategories = articleCategoryApplication.List();
        }

        public RedirectToPageResult OnPostRemove(long id)
        {
            articleCategoryApplication.Remove(id);
            return RedirectToPage("./list");
        }

        public RedirectToPageResult OnPostActivate(long id)
        {
            articleCategoryApplication.Activate(id);
            return RedirectToPage("./list");
        }
    }
}
