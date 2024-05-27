using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class EditModel(
        IArticleApplication articleApplication,
        IArticleCategoryApplication articleCategoryApplication)
        : PageModel
    {
        [BindProperty]
        public EditArticle Article { get; set; }
        public List<SelectListItem> ArticleCategories { get; set; }

        public void OnGet(long id)
        {
            Article = articleApplication
                .Get(id);
            ArticleCategories = articleCategoryApplication
                .List()
                .Select(x =>
                    new SelectListItem(x.Title,x.Id.ToString()))
                .ToList();
        }

        public RedirectToPageResult OnPost()
        {
            articleApplication.Edit(Article);
            return RedirectToPage("./list");
        }
    }
}
