using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Validators")]
    public class Validator
    {
        [Key]
        public int ValidatorId { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        public int ValidatorType { get; set; }

        public List<ValidatorArgment> Arguments { get; set; }
    }
}
