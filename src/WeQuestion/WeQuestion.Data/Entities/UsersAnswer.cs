using System.ComponentModel.DataAnnotations;

namespace WeQuestion.Data.Entities
{
    public class UsersAnswer
    {
        [Key]
        public int Id { get; set; }

        public virtual AnswerOption AnswerOption { get; set; }

        public virtual Question Question { get; set; }

        public virtual SurveyParticipation SurveyParticipation { get; set; }
    }
}
