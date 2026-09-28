using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vms_be.Dtos;
using vms_be.Services;

namespace vms_be.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : Controller
    {
        private readonly IVehiclesService _vehiclesService;

        public VehiclesController(IVehiclesService vehiclesService)
        { 
            _vehiclesService = vehiclesService;
        }

        // GET: /vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleResponseDto>>> GetAll()
        {
            var vehicles = await _vehiclesService.GetAll();
            return Ok(new { message = "Success", data = vehicles});
        }

        // POST: /vehicles
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VehicleResponseDto>> Create([FromBody] CreateVehicleDto dto)
        {
            var createdVehicle = await _vehiclesService.Create(dto);

            return Created("",  new { message = "Success", data = createdVehicle });
        }


        // PUT: vehicles/id
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleResponseDto>> Update(int id, [FromBody] UpdateVehicleDto dto)
        {
            var updatedVehicle = await _vehiclesService.Update(id, dto);

            if (updatedVehicle == null)
            {
                return NotFound(new
                {
                    message = "Vehicle not found"
                });
            }

            return Ok(new
            {
                message = "Success",
                data = updatedVehicle
            });
        }

        // DELETE: vehicles/id
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { message = "Invalid Vehicle ID." });
            }
            var deleted = await _vehiclesService.Delete(id);

            if (!deleted)
            { 
                return NotFound(new { message = "Vehicle Not Founded"});
            }
            return Ok(new { message = "Vehicle Details Deleted Successfully"});

        }
    }
}
