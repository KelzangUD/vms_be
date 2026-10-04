using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vms_be.Dtos;
using vms_be.Models;

namespace vms_be.Services
{
    public class CategoriesService : ICategoriesServices
    {
        private readonly ApplicationDbContext _context;

        public CategoriesService(ApplicationDbContext context)
        { 
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<CategoryResponseDto>>> GetAll()
        { 
            var categories = await _context.VehicleCategories.Select(c => new CategoryResponseDto
            { 
                Id = c.Id,
                CategoryName = c.CategoryName,
                StartWeight = c.StartWeight,
                IconName = c.IconName,
            }).ToListAsync();


            return categories;
        }

        public async Task<ActionResult<CategoryResponseDto>> Create(CreateCateogryDto dto)
        {
            var newCategory = new VehicleCategory
            {
                CategoryName = dto.CategoryName,
                StartWeight = dto.StartWeight,
                IconName = dto.IconName,
            };

            _context.VehicleCategories.Add(newCategory);
            await _context.SaveChangesAsync();

            var createdCategory = new CategoryResponseDto
            {
                Id = newCategory.Id,
                CategoryName = newCategory.CategoryName,
                StartWeight = newCategory.StartWeight,
                IconName = newCategory.IconName,
            };

            return createdCategory;
        }
        public async Task<CategoryResponseDto> Update(int id, UpdateCategoryDto dto)
        {
            
            var category = await _context.VehicleCategories.FirstOrDefaultAsync(v => v.Id == id);

            if (category == null)
            {
                return null;
            }

            category.CategoryName = dto.CategoryName;
            category.StartWeight = dto.StartWeight;
            category.IconName = dto.IconName;

            await _context.SaveChangesAsync();

           

            var updatedCategory = new CategoryResponseDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                StartWeight = category.StartWeight,
                IconName = category.IconName,
            };
            return updatedCategory;
        }
        public async Task<bool> Delete(int id)
        {

            var category = await _context.VehicleCategories.FindAsync(id);

            if (category == null)
            {
                return false;
            }

            _context.VehicleCategories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
