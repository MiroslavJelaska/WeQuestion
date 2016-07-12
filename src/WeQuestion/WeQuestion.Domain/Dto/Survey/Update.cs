using System.Collections.Generic;
using dto = WeQuestion.Domain.Dto;
namespace WeQuestion.Domain.Dto.Survey
{
    public class Update
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IReadOnlyCollection<dto::Question.Update> Questions { get; set; }
    }
}
