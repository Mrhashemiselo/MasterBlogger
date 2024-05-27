using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        : IArticleCategoryValidatorService
    {
        public void RecordAlreadyExist(string title)
        {
            if (articleCategoryRepository.Exist(title))
                throw new DuplicatedRecordException(message: "This record already exist");
        }
    }
}
