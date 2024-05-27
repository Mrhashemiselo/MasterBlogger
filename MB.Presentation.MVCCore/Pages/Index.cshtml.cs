using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class IndexModel(IArticleQuery articleQuery) : PageModel
    {
        public List<ArticleQueryView> Articles { get; set; }

        public void OnGet()
        {
            Articles = articleQuery.GetArticles();
        }
    }
}