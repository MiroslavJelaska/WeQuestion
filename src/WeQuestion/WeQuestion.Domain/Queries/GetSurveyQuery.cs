using WeQuestion.Data;
using WeQuestion.Domain.Mappers;
using dto = WeQuestion.Domain.Dto;


namespace WeQuestion.Domain.Queries
{
    public class GetSurveyQuery
    {
        public GetSurveyQuery(WeQuestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly WeQuestionDbContext _dbContext;

        public dto::Survey.LongDetails Execute(int id)
        {
            return
                SurveyMapper.LongDetails.Map(
                    _dbContext.Surveys.Find(id)
                );
        }
    }
}
