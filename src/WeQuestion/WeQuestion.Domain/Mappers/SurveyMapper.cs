using System;
using System.Collections.Generic;
using System.Linq;
using WeQuestion.Domain.Dto.Question;
using data = WeQuestion.Data.Entities;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Domain.Mappers
{
    public static class SurveyMapper
    {
        public static class ShortDetails
        {
            public static dto::Survey.ShortDetails Map(data::Survey survey)
            {
                return new dto::Survey.ShortDetails()
                {
                    Id               = survey.Id,
                    Title            = survey.Title,
                    AccessToken      = survey.AccessToken,
                    ClosingTimestamp = survey.ClosingTimestamp,
                    DurationInMinutes = survey.DurationInMinutes,
                    State            = MapSurveyState(survey)
                };
            }
        }

        public static class LongDetails
        {
            public static dto::Survey.LongDetails Map(data::Survey survey)
            {
                return new dto::Survey.LongDetails()
                {
                    Id               = survey.Id,
                    Title            = survey.Title,
                    AccessToken      = survey.AccessToken,
                    ClosingTimestamp = survey.ClosingTimestamp,
                    DurationInMinutes =  survey.DurationInMinutes,
                    Questions        = survey.Questions.Select(QustionMapper.Map).ToList(),
                    State            = MapSurveyState(survey)
                };
            }
        }

        private static dto.SurvayState MapSurveyState(data::Survey survey)
        {
            if(survey.State == data.SurvayState.Provisional)
                return dto.SurvayState.Provisional;
            if (survey.ClosingTimestamp.HasValue && DateTimeOffset.UtcNow < survey.ClosingTimestamp.Value)
                return dto.SurvayState.Open;
            return dto.SurvayState.Closed;
        }

        public static class Result
        {
            public static dto::Survey.Result Map(data::Survey survey)
            {
                return new dto::Survey.Result()
                {
                    Id = survey.Id,
                    ParticipantsCount = survey.SurveyParticipations.Count,
                    QuestionsWithResults = new List<DetailsWithResults>()
                };
            }
        }
    }
}
