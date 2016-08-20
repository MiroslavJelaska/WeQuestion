using System.Linq;
using WeQuestion.Data;
using WeQuestion.Data.Entities;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Domain.Commands
{
    public class ParticipateSurveyCommand
    {
        public ParticipateSurveyCommand(
            WeQuestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly WeQuestionDbContext _dbContext;

        public void Execute(dto::Survey.Participation participation)
        {
            var surveyParticipation = new SurveyParticipation()
            {
                //ProvisionalUser = participation.ProvisionalUser,
                Survey = _dbContext.Surveys.Single(x => x.AccessToken == participation.AccessToken),
                //UsersAnswers = participation.Answers.Select(a => new UsersAnswer()
                //{
                //    Question = _dbContext.Questions.Find(a.QuestionId)
                //}).ToList()
            };
            _dbContext.SurveyParticipations.Add(surveyParticipation);
            _dbContext.SaveChanges();
        }
    }
}
