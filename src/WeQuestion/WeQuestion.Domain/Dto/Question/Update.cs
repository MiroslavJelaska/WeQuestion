using System.Collections.Generic;
using dto = WeQuestion.Domain.Dto;


namespace WeQuestion.Domain.Dto.Question
{
    public class Update
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public IReadOnlyCollection<dto::Option.Update> Options { get; set; }
    }
}
