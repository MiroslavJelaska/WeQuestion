using System;
using System.Collections.Generic;
using WeQuestion.Data.Entities;
using dto =  WeQuestion.Domain.Dto;

namespace WeQuestion.Domain.Dto.Survey
{
    public class LongDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public SurvayState State { get; set; }

        public DateTimeOffset? ClosingTimestamp { get; set; }
        public int DurationInMinutes { get; set; }

        public string AccessToken { get; set; }

        public IReadOnlyCollection<dto::Question.Details> Questions { get; set; }
    }
}
