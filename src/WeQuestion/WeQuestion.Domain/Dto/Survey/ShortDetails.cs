using System;
using WeQuestion.Data.Entities;

namespace WeQuestion.Domain.Dto.Survey
{
    public class ShortDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public SurvayState State { get; set; }

        public DateTimeOffset? ClosingTimestamp { get; set; }

        public string AccessToken { get; set; }
    }
}
