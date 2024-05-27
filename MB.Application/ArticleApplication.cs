using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application;
public class ArticleApplication(IArticleRepository articleRepository) : IArticleApplication
{
    public void Activate(long id)
    {
        var article = articleRepository.GetArticle(id);
        article.Active();
        articleRepository.Save();

    }

    public void Create(CreateArticle command)
    {
        var article = new Article(
            command.Title,
            command.ShortDescription,
            command.Image,
            command.Content,
            command.ArticleCategoryId
            );
        articleRepository.CreateAndSave(article);
    }

    public void Edit(EditArticle command)
    {
        var article = articleRepository.GetArticle(command.Id);
        article.Edit(command.Title,command.ShortDescription, command.Image,command.Content,command.ArticleCategoryId);
        articleRepository.Save();
    }

    public EditArticle Get(long id)
    {
        var article = articleRepository
            .GetArticle(id);
        return new EditArticle()
        {
            Title = article.Title,
            ArticleCategoryId = article.ArticleCategoryId,
            Content = article.Content,
            Id = article.Id,
            Image = article.Image,
            ShortDescription = article.ShortDescription
        };
    }

    public List<ArticleViewModel> GetList()
    {
        return articleRepository.GetList();
    }

    public void Remove(long id)
    {
        var article = articleRepository.GetArticle(id);
        article.Remove();
        articleRepository.Save();
    }
}
