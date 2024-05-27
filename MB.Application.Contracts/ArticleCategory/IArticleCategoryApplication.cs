namespace MB.Application.Contracts.ArticleCategory;

public interface IArticleCategoryApplication
{
    List<ArticleCategoryViewModel> List();
    void Create(CreateArticleCategory command);
    void Rename(RenameArticleCategory command);
    RenameArticleCategory GetById(long id);
    void Remove(long id);
    void Activate(long id);
}
