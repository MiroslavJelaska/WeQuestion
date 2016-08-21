using System.Collections.Generic;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Domain.Dto.Survey
{
    public class Result
    {
        public int Id { get; set; }
        
        public int ParticipantsCount { get; set; }

        public IReadOnlyCollection<dto::Question.DetailsWithResults> QuestionsWithResults { get; set; }
    }
}
