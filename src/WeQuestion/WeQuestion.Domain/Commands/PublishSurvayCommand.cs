using System;
using WeQuestion.Data;
using WeQuestion.Data.Entities;
using WeQuestion.Domain.Mappers;
using WeQuestion.Domain.Services;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Domain.Commands
{
    public class PublishSurveyCommand
    {
        public PublishSurveyCommand(
            AccessTokenGenerator accessTokenGenerator,
            WeQuestionDbContext dbContext)
        {
            _accessTokenGenerator = accessTokenGenerator;
            _dbContext = dbContext;
        }

        private readonly AccessTokenGenerator _accessTokenGenerator;
        private readonly WeQuestionDbContext _dbContext;

        public dto::Survey.ShortDetails Execute(dto::Survey.Publish publishSurvay)
        {
            var surveyRecord = _dbContext.Surveys.Find(publishSurvay.Id);
            surveyRecord.State = SurvayState.Published;
            surveyRecord.ClosingTimestamp = DateTimeOffset.UtcNow.AddMinutes(publishSurvay.DurationInMinutes);
            surveyRecord.DurationInMinutes = publishSurvay.DurationInMinutes;
            surveyRecord.AccessToken = _accessTokenGenerator.Generate();

            _dbContext.SaveChanges();

            return  SurveyMapper.ShortDetails.Map(surveyRecord);
        }
    }
}
