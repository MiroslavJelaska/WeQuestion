using System.Collections.Generic;
using dto = WeQuestion.Domain.Dto;
namespace WeQuestion.Domain.Dto.Survey
{
    public class Create
    {
        public string Title { get; set; }

        public IReadOnlyCollection<dto::Question.Create> Questions { get; set; }
    }
}
