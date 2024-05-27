using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class EditModel(IArticleCategoryApplication articleCategoryApplication) : PageModel
    {
        [BindProperty]
        public RenameArticleCategory ArticleCategory { get; set; }

        public void OnGet(long id)
        {
            ArticleCategory = articleCategoryApplication.GetById(id);
        }

        public RedirectToPageResult OnPost()
        {
            articleCategoryApplication.Rename(ArticleCategory);
            return RedirectToPage("./list");
        }
    }
}
