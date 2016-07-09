using data = WeQuestion.Data.Entities;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Domain.Mappers
{
    public static class QustionMapper
    {
        public static dto::Question.Details Map(data::Question question)
        {
            return new dto::Question.Details()
            {
                Id   = question.Id,
                Text = question.Text
            };
        }
    }
}
