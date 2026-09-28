using vms_be.Dtos;

namespace vms_be.Services
{
    public interface IVehiclesService
    {
        Task<IEnumerable<VehicleResponseDto>> GetAll();
        Task<VehicleResponseDto> Create(CreateVehicleDto dto);
        Task<VehicleResponseDto> Update(int id, UpdateVehicleDto dto);
        Task<bool> Delete(int id);
    }
}
