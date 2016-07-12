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
            var surveyRecord = new Survey()
            {
                Title = newSurvay.Title,
                State = SurvayState.Provisional,
                Questions = _getQuestionsWithRelatedOptions(newSurvay)
            };
            _dbContext.Surveys.Add(surveyRecord);


            _dbContext.SaveChanges();

            return  SurveyMapper.ShortDetails.Map(surveyRecord);
        }
        private ICollection<Question> _getQuestionsWithRelatedOptions(dto::Survey.Create newSurvey)
        {
            return
                newSurvey.Questions != null
                ? (Enumerable.Range(0, newSurvey.Questions.Count)
                .Zip(
                    second:         newSurvey.Questions,
                    resultSelector: (i, question) => new { index = i, question }
                )
                .Select(newQuestion => new Question()
                {
                    Index         = newQuestion.index,
                    Text          = newQuestion.question.Text,
                    AnswerOptions = _getOptionsForQuestion(newQuestion.question)
                })
                .ToList())
                : new List<Question>();
        }

        private ICollection<AnswerOption> _getOptionsForQuestion(dto::Question.Create newQuestion)
        {
            return
                newQuestion.Options != null
                ? (Enumerable.Range(0, newQuestion.Options.Count)
                .Zip(
                    second:         newQuestion.Options,
                    resultSelector: (i, option) => new { index = i, option }
                )
                .Select(newOption => new AnswerOption()
                {
                    Index     = newOption.index,
                    Text      = newOption.option.Text,
                    IsCorrect = newOption.option.IsCorrect
                })
                .ToList())
                : new List<AnswerOption>();
        }
    }
}
