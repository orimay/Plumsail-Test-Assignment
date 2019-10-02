using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("QuestionSets")]
    public class QuestionSet
    {
        [Key]
        public int QuestionSetId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Title { get; set; }

        public List<Question> Questions { get; set; }
    }
}
