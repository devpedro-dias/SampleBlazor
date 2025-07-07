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
        public Category Create(Category obj)
        {
            _context.Category.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var obj = _context.Category.FirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                _context.Category.Remove(obj);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public Category Get(int id)
        {
            var obj = _context.Category.FirstOrDefault(u => u.Id == id);
            if(obj == null)
            {
                return new Category();
            }
            return obj;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        public Category Update(Category obj)
        {
            var objFromDb = _context.Category.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb is not null)
            {
                objFromDb.Name = obj.Name;
                _context.Category.Update(objFromDb);
                _context.SaveChanges();
                return objFromDb;
            }
            return obj;
        }
    }
}
