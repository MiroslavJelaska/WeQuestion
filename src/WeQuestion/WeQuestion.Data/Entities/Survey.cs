using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeQuestion.Data.Entities
{
    public class Survey
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public SurvayState State { get; set; }

        public DateTimeOffset? ClosingTimestamp { get; set; }
        public int             DurationInMinutes { get; set; }
        public string AccessToken { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
