using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vms_be.Models
{
    public class VehicleCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string CategoryName { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "It Must be a Positive Value")]
        [Column(TypeName = "decimal(18,2)")]
        public required double StartWeight { get; set; }
        public required string IconName { get; set; }
    }
}
