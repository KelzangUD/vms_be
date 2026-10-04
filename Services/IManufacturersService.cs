using Microsoft.AspNetCore.Mvc;
using vms_be.Dtos;

namespace vms_be.Services
{
    public interface IManufacturersService
    {
        Task<ActionResult<IEnumerable<ManufacturerResponseDto>>> GetAll();
    }
}
