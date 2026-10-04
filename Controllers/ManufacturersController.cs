using Microsoft.AspNetCore.Mvc;
using vms_be.Dtos;
using vms_be.Services;

namespace vms_be.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ManufacturersController : Controller
    {
        private readonly IManufacturersService _manufacturersService;
        private readonly ApplicationDbContext _context;

        public ManufacturersController(IManufacturersService manufactuerersService, ApplicationDbContext context)
        {
            _manufacturersService = manufactuerersService;
            _context = context;
        }

        // GET: /manufacturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManufacturerResponseDto>>> GetAll()
        {
            var result = await _manufacturersService.GetAll();
            var manufacturers = result.Value ?? (result.Result as OkObjectResult)?.Value;
            return Ok(new { message = "Success", data = manufacturers });
        }  
    }
}
