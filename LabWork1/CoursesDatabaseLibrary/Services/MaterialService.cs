using CoursesDatabaseLibrary.Contexts;
using CoursesDatabaseLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CoursesDatabaseLibrary.Services
{
    public class MaterialService
    {
        private readonly CoursesContext _context = new();

        public async Task CreateMaterialAsync(int topicId, string title, int materialTypeId, string content)
        {
            Material material = new()
            {
                TopicId = topicId,
                Title = title,
                MaterialTypeId = materialTypeId,
                Content = content
            };

            await _context.Materials.AddAsync(material);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMaterialAsync(int id)
        {
            Material? selectedMaterial = await _context.Materials.FirstOrDefaultAsync(m => m.Id == id);

            if (selectedMaterial is null)
                return;

            _context.Materials.Remove(selectedMaterial);
            await _context.SaveChangesAsync();
        }

        public async Task<Material?> GetMaterialByIdAsync(int id)
        {
            Material? selectedMaterial = await _context.Materials.FirstOrDefaultAsync(m => m.Id == id);
            return selectedMaterial;
        }

        public async Task UpdateMaterialAsync(int id, int topicId, string title, int materialTypeId, string content)
        {
            Material? selectedMaterial = await _context.Materials.FirstOrDefaultAsync(m => m.Id == id);

            if (selectedMaterial is null)
                return;

            selectedMaterial.TopicId = topicId;
            selectedMaterial.Title = title;
            selectedMaterial.MaterialTypeId = materialTypeId;
            selectedMaterial.Content = content;

            _context.Materials.Update(selectedMaterial);
            await _context.SaveChangesAsync();
        }
    }
}
