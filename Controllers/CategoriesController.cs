using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vms_be.Dtos;
using vms_be.Services;

namespace vms_be.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesServices _categoriesService;
        private readonly ApplicationDbContext _context;

        public CategoriesController(ICategoriesServices categoriesServices, ApplicationDbContext context)
        {
            _categoriesService = categoriesServices;
            _context = context;
        }

        // GET: /categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponseDto>>> GetAll()
        {
            var result = await _categoriesService.GetAll();
            var categories = result.Value ?? (result.Result as OkObjectResult)?.Value;
            return Ok(new {  message = "Success", data = categories });
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<CategoryResponseDto>> Create([FromBody] CreateCateogryDto dto)
        {
            bool exists = await _context.VehicleCategories.AnyAsync(c => c.StartWeight == dto.StartWeight);
            if (exists)
            {
                return Conflict(new
                {
                    message = $"A Category with weight '{dto.StartWeight}' alreay exist"
                });
            }
            var createdCategory = await _categoriesService.Create(dto);
            return Created("", new { message = "Success", data = createdCategory });
        }

        // PUT: categories/id
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryResponseDto>> Update(int id, [FromBody] UpdateCategoryDto dto)
        {
            var updatedVehicle = await _categoriesService.Update(id, dto);

            if (updatedVehicle == null)
            {
                return NotFound(new
                {
                    message = "Category not found"
                });
            }

            return Ok(new
            {
                message = "Success",
                data = updatedVehicle
            });
        }

        // DELETE: categories/id
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { message = "Invalid Vehicle Category ID." });
            }
            var deleted = await _categoriesService.Delete(id);

            if (!deleted)
            {
                return NotFound(new { message = "Vehicle Category Not Founded" });
            }
            return Ok(new { message = "Vehicle Category Deleted Successfully" });

        }
    }
}
