using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("ValidatorsArgments")]
    public class ValidatorArgment
    {
        [Key]
        public int ValidatorArgumentId { get; set; }

        [ForeignKey("Validator")]
        public int ValidatorId { get; set; }

        public string Value { get; set; }
    }
}
