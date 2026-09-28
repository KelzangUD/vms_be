using System.ComponentModel.DataAnnotations;

namespace vms_be.Dtos
{
    public class CreateVehicleDto
    {
        public required string OwnerName { get; set; } = string.Empty;
        public int? ManufacturerId { get; set; }
        public string? OtherManufacturerName { get; set; }

        public required int YearOfManufacturer { get; set; }

        [Range(0, double.MaxValue)]
        public double Weight { get; set; }
    }
}
