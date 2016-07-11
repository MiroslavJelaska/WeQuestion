using System.Collections.Generic;

namespace WeQuestion.Domain.Dto.Question
{
    public class Create
    {
        public string Title { get; set; }

        public IReadOnlyCollection<Option.Create> Options { get; set; }
    }
}
