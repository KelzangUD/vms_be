using Microsoft.AspNetCore.Mvc;
using vms_be.Dtos;

namespace vms_be.Services
{
    public interface ICategoriesServices
    {
        Task<ActionResult<IEnumerable<CategoryResponseDto>>> GetAll();
        Task<ActionResult<CategoryResponseDto>> Create(CreateCateogryDto dto);
        Task<CategoryResponseDto> Update(int id, UpdateCategoryDto dto);
        Task<bool> Delete(int id);
    }
}
