using System.Collections.Generic;
using dto =  WeQuestion.Domain.Dto;

namespace WeQuestion.Domain.Dto.Results
{
    public class LongDetails
    {
        public int Id { get; set; }

        public IReadOnlyCollection<dto::Question.Details> QuestionsWithAnswers { get; set; }
    }
}
