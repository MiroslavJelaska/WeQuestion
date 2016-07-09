using data = WeQuestion.Data.Entities;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Domain.Mappers
{
    public static class SurveyMapper
    {
        public static dto::Survey.ShortDetails Map(data::Survey survey)
        {
            return new dto::Survey.ShortDetails()
            {
                Id               = survey.Id,
                Title            = survey.Title,
                AccessToken      = survey.AccessToken,
                ClosingTimestamp = survey.ClosingTimestamp
            };
        }
    }
}
