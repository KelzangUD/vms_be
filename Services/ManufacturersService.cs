using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vms_be.Dtos;
using vms_be.Models;

namespace vms_be.Services
{
    public class ManufacturersService : IManufacturersService
    {
        private readonly ApplicationDbContext _context;

        public ManufacturersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<ManufacturerResponseDto>>> GetAll()
        {
            var manufacturers = await _context.Manufacturers.Select(m => new ManufacturerResponseDto
            {
                Id = m.Id,
                Name = m.Name,
            }).ToListAsync();
            return manufacturers;
        }
    }
}
