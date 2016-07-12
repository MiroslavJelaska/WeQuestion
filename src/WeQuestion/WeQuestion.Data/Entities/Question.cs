using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeQuestion.Data.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public int Index { get; set; }

        public virtual ICollection<AnswerOption> AnswerOptions { get; set; }
    }
}
