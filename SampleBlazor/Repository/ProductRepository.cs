using Microsoft.EntityFrameworkCore;
using SampleBlazor.Data;
using SampleBlazor.Repository.Interfaces;

namespace SampleBlazor.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductRepository(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _context = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<Product> CreateAsync(Product obj)
        {
            await _context.Product.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _context.Product.FirstOrDefaultAsync(u => u.Id == id);
            //var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('/'));
            //if(File.Exists(imagePath))
            //{
            //    File.Delete(imagePath);
            //}
            if (obj != null)
            {
                _context.Product.Remove(obj);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Product> GetAsync(int id)
        {
            var obj = await _context.Product.FirstOrDefaultAsync(u => u.Id == id);
            if (obj == null)
            {
                return new Product();
            }
            return obj;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Product.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product obj)
        {
            var objFromDb = await _context.Product.FirstOrDefaultAsync(u => u.Id == obj.Id);
            if (objFromDb is not null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.Price = obj.Price;
                objFromDb.CategoryId = obj.CategoryId;
                _context.Product.Update(objFromDb);
                await _context.SaveChangesAsync();
                return objFromDb;
            }
            return obj;
        }
    }
}
