using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Questions")]
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [ForeignKey("QuestionSet")]
        public int QuestionSetId { get; set; }

        public int InputType { get; set; }

        public string Label { get; set; }

        public List<QuestionOption> Options { get; set; }

        public List<Validator> Validators { get; set; }
    }
}
