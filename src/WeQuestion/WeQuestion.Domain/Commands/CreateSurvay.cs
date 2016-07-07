using WeQuestion.Data;
using WeQuestion.Data.Entities;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Domain.Commands
{
    public class CreateSurvay
    {
        public CreateSurvay(WeQuestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly WeQuestionDbContext _dbContext;

        public int Execute(dto::Survey.Create newSurvay)
        {
            var surveyRecord = new Survey()
            {
                Title = newSurvay.Title
            };
            _dbContext.Surveys.Add(surveyRecord);

            return surveyRecord.Id;
        }
    }
}
