using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Answers")]
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        [ForeignKey("AnswerSet")]
        public int AnswerSetId { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        public string Value { get; set; }

        public List<AnswerOption> Options { get; set; }
    }
}
