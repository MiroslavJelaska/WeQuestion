using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WeQuestion.Data;
using WeQuestion.Data.Entities;
using WeQuestion.Domain.Mappers;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Domain.Commands
{
    public class UpdateSurvayCommand
    {
        public UpdateSurvayCommand(WeQuestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly WeQuestionDbContext _dbContext;

        public dto::Survey.LongDetails Execute(dto::Survey.Update updatedSurvey)
        {
            _deleteQuestionsAndRelatedOptions(updatedSurvey);

            var surveyRecord       = _dbContext.Surveys.Find(updatedSurvey.Id);
            surveyRecord.Title     = updatedSurvey.Title;
            surveyRecord.Questions = _getQuestionsWithRelatedOptions(updatedSurvey);

            _dbContext.SaveChanges();

            return  SurveyMapper.LongDetails.Map(surveyRecord);
        }

        private void _deleteQuestionsAndRelatedOptions(dto::Survey.Update updatedSurvey)
        {
            var survey = _dbContext.Surveys.Find(updatedSurvey.Id);
            foreach (var question in survey.Questions.ToList())
            {
                foreach (var answerOption in question.AnswerOptions.ToList())
                {
                    _dbContext.Entry(answerOption).State = EntityState.Deleted;
                }
                _dbContext.Entry(question).State = EntityState.Deleted;
            }
        }

        private ICollection<Question> _getQuestionsWithRelatedOptions(dto::Survey.Update updatedSurvey)
        {
            return
                updatedSurvey.Questions != null
                ? (Enumerable.Range(0, updatedSurvey.Questions.Count)
                .Zip(
                    second:         updatedSurvey.Questions,
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

        private ICollection<AnswerOption> _getOptionsForQuestion(dto::Question.Update newQuestion)
        {
            return
                newQuestion.Options != null
                ? (Enumerable.Range(0, newQuestion.Options.Count)
                .Zip(
                    second:         newQuestion.Options,
                    resultSelector: (i, option) => new {index = i, option}
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
