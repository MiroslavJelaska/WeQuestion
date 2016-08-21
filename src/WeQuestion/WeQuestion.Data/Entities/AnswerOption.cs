using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeQuestion.Data.Entities
{
    public class AnswerOption
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public int Index { get; set; }

        public bool IsCorrect { get; set; }

        public virtual ICollection<UsersAnswer> UsersAnswers { get; set; }
    }
}
