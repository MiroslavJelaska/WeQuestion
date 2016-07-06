using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeQuestion.Data.Entities
{
    public class SurveyParticipation
    {
        [Key]
        public int Id { get; set; }

        public string Comment { get; set; }


        public virtual ICollection<UsersAnswer> UsersAnswers { get; set; }

        public virtual Survey Survey { get; set; }

        public virtual ProvisionalUser ProvisionalUser { get; set; }
    }
}
