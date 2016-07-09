using WeQuestion.Data;
using WeQuestion.Data.Entities;
using WeQuestion.Domain.Mappers;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Domain.Commands
{
    public class CreateSurvayCommand
    {
        public CreateSurvayCommand(WeQuestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly WeQuestionDbContext _dbContext;

        public dto::Survey.ShortDetails Execute(dto::Survey.Create newSurvay)
        {
            var surveyRecord = new Survey()
            {
                Title = newSurvay.Title
            };
            _dbContext.Surveys.Add(surveyRecord);

            _dbContext.SaveChanges();

            return  SurveyMapper.Map(surveyRecord);
        }
    }
}
