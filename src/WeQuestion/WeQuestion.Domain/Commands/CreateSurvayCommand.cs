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
                Enumerable.Range(0, newSurvay.Questions.Count)
                .Zip(
                    second:         newSurvay.Questions,
                    resultSelector: (i, question) => new { index = i, question }
                )
                .Select(newQuestion => new Question()
                {
                    Index         = newQuestion.index,
                    Text          = newQuestion.question.Text,
                    AnswerOptions =
                        Enumerable.Range(0, newQuestion.question.Options.Count)
                        .Zip(
                            second:         newQuestion.question.Options,
                            resultSelector: (i, option) => new { index = i, option }
                        )
                        .Select(newOption => new AnswerOption()
                        {
                            Index     = newQuestion.index,
                            Text      = newOption.option.Text,
                            IsCorrect = newOption.option.IsCorrect
                        })
                        .ToList()
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
