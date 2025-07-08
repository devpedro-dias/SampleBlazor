using Microsoft.EntityFrameworkCore;
using SampleBlazor.Data;
using SampleBlazor.Repository.Interfaces;

namespace SampleBlazor.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext db)
        {
            _context = db;
        }
        public async Task<Category> CreateAsync(Category obj)
        {
            await _context.Category.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _context.Category.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _context.Category.Remove(obj);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Category> GetAsync(int id)
        {
            var obj = await _context.Category.FirstOrDefaultAsync(u => u.Id == id);
            if(obj == null)
            {
                return new Category();
            }
            return obj;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> UpdateAsync(Category obj)
        {
            var objFromDb = await _context.Category.FirstOrDefaultAsync(u => u.Id == obj.Id);
            if (objFromDb is not null)
            {
                objFromDb.Name = obj.Name;
                _context.Category.Update(objFromDb);
                await _context.SaveChangesAsync();
                return objFromDb;
            }
            return obj;
        }
    }
}
