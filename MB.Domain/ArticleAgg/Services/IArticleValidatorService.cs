namespace MB.Domain.ArticleAgg.Services
{
    public interface IArticleValidatorService
    {
        void RecordAlreadyExist(string title);
    }
}
