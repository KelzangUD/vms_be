using System.ComponentModel.DataAnnotations;

namespace vms_be.Dtos
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "It Must be a Positive Value")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Weight cannot have more than 2 decimal places.")]
        public double StartWeight { get; set; }
        public string IconName { get; set; }
    }
}
