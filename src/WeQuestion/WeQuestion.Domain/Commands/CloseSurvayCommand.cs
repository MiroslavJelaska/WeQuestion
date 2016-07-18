using WeQuestion.Data;
using WeQuestion.Domain.Mappers;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Domain.Commands
{
    public class CloseSurvayCommand
    {
        public CloseSurvayCommand(WeQuestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly WeQuestionDbContext _dbContext;

        public dto::Survey.LongDetails Execute(int closeSurveyId)
        {
            var surveyRecord = _dbContext.Surveys.Find(closeSurveyId);
            surveyRecord.ClosingTimestamp = null;

            _dbContext.SaveChanges();

            return  SurveyMapper.LongDetails.Map(surveyRecord);
        }
    }
}
