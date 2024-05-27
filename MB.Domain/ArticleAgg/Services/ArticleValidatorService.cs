using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleAgg.Services
{
    public class ArticleValidatorService(IArticleRepository articleRepository) : IArticleValidatorService
    {
        public void RecordAlreadyExist(string title)
        {
            if(articleRepository.Exist(title)) 
            {
                throw new DuplicatedRecordException();
            }
        }
    }
}
