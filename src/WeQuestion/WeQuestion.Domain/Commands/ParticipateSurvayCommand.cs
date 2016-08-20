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
            var userRecord = _dbContext.ProvisionalUsers.Find(participation.ProvisionalUserId);
            if (userRecord == null)
            {
                userRecord = new ProvisionalUser();
                _dbContext.ProvisionalUsers.Add(userRecord);
            }

            var surveyParticipation = new SurveyParticipation()
            {
                ProvisionalUser = userRecord,
                Survey = _dbContext.Surveys.Single(x => x.AccessToken == participation.AccessToken),
                UsersAnswers = participation.Answers.Select(a => new UsersAnswer()
                {
                    AnswerOption = _dbContext.AnswerOptions.Find(a.SelectedOptionId)
                }).ToList()
            };
            _dbContext.SurveyParticipations.Add(surveyParticipation);

            _dbContext.SaveChanges();
        }
    }
}
