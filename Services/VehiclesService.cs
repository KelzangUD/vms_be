using Microsoft.EntityFrameworkCore;
using vms_be.Dtos;
using vms_be.Models;

namespace vms_be.Services
{
    public class VehiclesService : IVehiclesService
    {
        private readonly ApplicationDbContext _context;

        public VehiclesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleResponseDto>> GetAll()
        {
            var categories = await _context.VehicleCategories.OrderByDescending(vc => vc.StartWeight).ToListAsync();
            
            var vehicles  = await _context.VehicleDetails.Select(v => new VehicleResponseDto
            {
                Id = v.Id,
                OwnerName = v.OwnerName,
                ManufacturerId = v.ManufacturerId,
                ManufacturerName = v.Manufacturer != null ? v.Manufacturer.Name : string.Empty,
                OtherManufacturerName = v.OtherManufacturerName,
                YearOfManufacturer = v.YearOfManufacturer,
                Weight = v.Weight
            }).ToListAsync();

            foreach (var vehicle in vehicles)
            {
                var category = categories.FirstOrDefault(c => vehicle.Weight >= c.StartWeight);

                if (category != null)
                { 
                    vehicle.CategoryId = category.Id;
                    vehicle.CategoryName = category.CategoryName;
                    vehicle.IconName = category.IconName;
                }
            }
            return vehicles;
        }

        public async Task<VehicleResponseDto> Create(CreateVehicleDto dto)
        {
            var categories = await _context.VehicleCategories.OrderByDescending(vc => vc.StartWeight).ToListAsync();
            var vehicle = new VehicleDetails
            {
                OwnerName = dto.OwnerName,
                ManufacturerId = dto.ManufacturerId,
                OtherManufacturerName = dto.OtherManufacturerName,
                YearOfManufacturer = dto.YearOfManufacturer,
                Weight = dto.Weight
            };

            _context.VehicleDetails.Add(vehicle);
            await _context.SaveChangesAsync();

            var manufaturer = await _context.Manufacturers.FindAsync(vehicle.ManufacturerId);
            var category = categories.FirstOrDefault(c => vehicle.Weight >= c.StartWeight);

            var newVehicle = new VehicleResponseDto
            {
                Id = vehicle.Id,
                OwnerName = vehicle.OwnerName,
                ManufacturerId = vehicle.ManufacturerId,
                ManufacturerName = manufaturer?.Name ?? string.Empty,
                OtherManufacturerName = vehicle.OtherManufacturerName,
                YearOfManufacturer = vehicle.YearOfManufacturer,
                Weight = vehicle.Weight
            };

            if (category != null)
            {
                newVehicle.CategoryId = category.Id;
                newVehicle.CategoryName = category.CategoryName;
                newVehicle.IconName = category.IconName;
            }
            return newVehicle;
        }

        public async Task<VehicleResponseDto> Update(int id, UpdateVehicleDto dto)
        {
            var categories = await _context.VehicleCategories.OrderByDescending(vc => vc.StartWeight).ToListAsync();
            var vehicle = await _context.VehicleDetails.FirstOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
            {
                return null;
            }

            vehicle.OwnerName = dto.OwnerName;
            vehicle.ManufacturerId = dto.ManufacturerId;
            vehicle.OtherManufacturerName = dto.OtherManufacturerName;
            vehicle.YearOfManufacturer = dto.YearOfManufacturer;
            vehicle.Weight = dto.Weight;

            await _context.SaveChangesAsync();

            var category = categories.FirstOrDefault(c => vehicle.Weight >= c.StartWeight);

            var updatedVehicle = new VehicleResponseDto
            {
                Id = vehicle.Id,
                OwnerName = vehicle.OwnerName,
                ManufacturerId = vehicle.ManufacturerId,
                OtherManufacturerName = vehicle.OtherManufacturerName,
                YearOfManufacturer = vehicle.YearOfManufacturer,
                Weight = vehicle.Weight
            };
            if (category != null)
            {
                updatedVehicle.CategoryId = category.Id;
                updatedVehicle.CategoryName = category.CategoryName;
                updatedVehicle.IconName = category.IconName;
            }
            return updatedVehicle;
        }

        public async Task<bool> Delete(int id)
        {

            var vehicle = await _context.VehicleDetails.FindAsync(id);

            if (vehicle == null)
            {
                return false;
            }
            
            _context.VehicleDetails.Remove(vehicle);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
