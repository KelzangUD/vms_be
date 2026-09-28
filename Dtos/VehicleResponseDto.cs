namespace vms_be.Dtos
{
    public class VehicleResponseDto
    {
        public int Id { get; set; }
        public string OwnerName { get; set; } = string.Empty;
        public int? ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = string.Empty;

        public string? OtherManufacturerName { get; set; }
        public int YearOfManufacturer { get; set; }
        public double Weight { get; set; }

        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string IconName { get; set; }
    }
}
