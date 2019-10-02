using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("QuestionOptions")]
    public class QuestionOption
    {
        [Key]
        public int QuestionOptionId { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        public string Text { get; set; }
    }
}
