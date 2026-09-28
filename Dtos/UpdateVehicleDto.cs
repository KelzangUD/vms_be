namespace vms_be.Dtos
{
    public class UpdateVehicleDto
    {
        public int Id { get; set; }
        public string OwnerName { get; set; } = string.Empty;
        public int? ManufacturerId { get; set; }
        public string? OtherManufacturerName { get; set; }
        public int YearOfManufacturer { get; set; }
        public double Weight { get; set; }
    }
}
