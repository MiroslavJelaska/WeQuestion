using WeQuestion.Data;
using WeQuestion.Domain.Mappers;
using dto = WeQuestion.Domain.Dto;


namespace WeQuestion.Domain.Queries
{
    public class GetSurveyResultQuery
    {
        public GetSurveyResultQuery(WeQuestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly WeQuestionDbContext _dbContext;

        public dto::Survey.Result Execute(int id)
        {
            return
                SurveyMapper.Result.Map(
                    _dbContext.Surveys.Find(id)
                );
        }
    }
}
