using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeQuestion.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Survey> Surveys { get; set; }
    }
}
