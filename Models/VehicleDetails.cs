using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vms_be.Models
{
    public class VehicleDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public required string OwnerName { get; set; }

        public required int ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]
        public Manufacturer? Manufacturer { get; set; }

        public string? OtherManufacturerName { get; set; }

        public required int YearOfManufacturer { get; set; }

        public required double Weight { get; set; }
    }
}
