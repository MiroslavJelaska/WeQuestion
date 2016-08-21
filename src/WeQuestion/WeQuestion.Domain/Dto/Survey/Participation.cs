using System;
using System.Collections.Generic;
using dto = WeQuestion.Domain.Dto;
namespace WeQuestion.Domain.Dto.Survey
{
    public class Participation
    {
        public string AccessToken { get; set; }
        public Guid ProvisionalUserId { get; set; }
        public IReadOnlyCollection<dto::UserAnswer.Details> Answers { get; set; }
        public string Comment { get; set; }
    }
}
