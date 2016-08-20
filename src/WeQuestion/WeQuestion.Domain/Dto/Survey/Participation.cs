using System;
using System.Collections.Generic;
using WeQuestion.Data.Entities;
using dto = WeQuestion.Domain.Dto;
namespace WeQuestion.Domain.Dto.Survey
{
    public class Participation
    {
        public string AccessToken { get; set; }

        //public IReadOnlyCollection<dto::UserAnswer.Details> Answers { get; set; }

        //public ProvisionalUser ProvisionalUser { get; set; }
    }
}
