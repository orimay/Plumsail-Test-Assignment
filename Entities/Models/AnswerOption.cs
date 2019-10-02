using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("AnswerOptions")]
    public class AnswerOption
    {
        [Key]
        public int AnswerOptionId { get; set; }

        [ForeignKey("Answer")]
        public int AnswerId { get; set; }

        [ForeignKey("QuestionOptions")]
        public int QuestionOptionId { get; set; }

        public QuestionOption QuestionOption { get; set; }
    }
}
