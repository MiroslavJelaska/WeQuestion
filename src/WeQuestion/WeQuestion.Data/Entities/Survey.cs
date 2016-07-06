using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace WeQuestion.Data.Entities
{
    public class Survey
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public bool IsPublished { get; set; }
        public bool IsOpen { get; set; }

        public DateTimeOffset ClosingTimestamp { get; set; }

        public string AccessToken { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
