namespace MB.Domain.ArticleCategoryAgg;

public interface IArticleCategoryRepository
{
    List<ArticleCategory> GetAll();
    void Add(ArticleCategory entity);
    ArticleCategory GetById(long id);
    void Save();
    bool Exist(string title);
}
