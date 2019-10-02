using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("AnswerSets")]
    public class AnswerSet
    {
        [Key]
        public int AnswerSetId { get; set; }

        [ForeignKey("QuestionSet")]
        public int QuestionSetId { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
