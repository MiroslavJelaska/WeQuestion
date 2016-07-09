using System.Linq;
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
                    State            = survey.State
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
                    Questions        = survey.Questions.Select(QustionMapper.Map).ToList(),
                    State            = survey.State
                };
            }
        }
    }
}
