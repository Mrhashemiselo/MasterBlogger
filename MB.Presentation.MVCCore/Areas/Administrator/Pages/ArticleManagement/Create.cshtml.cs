using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class CreateModel(
        IArticleCategoryApplication articleCategoryApplication,
        IArticleApplication articleApplication)
        : PageModel
    {
        public List<SelectListItem> ArticleCategories { get; set; }

        public void OnGet()
        {
            ArticleCategories = articleCategoryApplication
                .List()
                .Select(x=> new SelectListItem(x.Title,x.Id.ToString()))
                .ToList();
        }

        public RedirectToPageResult OnPost(CreateArticle command)
        {
            articleApplication.Create(command);
            return RedirectToPage("./List");
        }
    }
}
