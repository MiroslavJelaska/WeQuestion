using System.Collections.Generic;
using System.Linq;
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
            var questionRecords = 
                newSurvay.Questions
                .Select(newQuestion => new Question()
                {
                    Text = newQuestion.Title
                })
                .ToList();

            var surveyRecord = new Survey()
            {
                Title = newSurvay.Title,
                State = SurvayState.Provisional,
                Questions = questionRecords
            };
            _dbContext.Surveys.Add(surveyRecord);


            _dbContext.SaveChanges();

            return  SurveyMapper.ShortDetails.Map(surveyRecord);
        }
    }
}
