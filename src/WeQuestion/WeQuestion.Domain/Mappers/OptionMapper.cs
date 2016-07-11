using data = WeQuestion.Data.Entities;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Domain.Mappers
{
    public static class OptionMapper
    {
        public static dto::Option.Details Map(data::AnswerOption option)
        {
            return new dto::Option.Details()
            {
                Id   = option.Id,
                Text = option.Text
            };
        }
    }
}
