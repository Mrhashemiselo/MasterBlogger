using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class CreateModel(IArticleCategoryApplication articleCategoryApplication) : PageModel
    {
        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost(CreateArticleCategory command) 
        {
            articleCategoryApplication.Create(command);
            return RedirectToPage("./list");
        }
    }
}
