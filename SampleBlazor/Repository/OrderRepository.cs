using Microsoft.EntityFrameworkCore;
using SampleBlazor.Data;
using SampleBlazor.Repository.Interfaces;

namespace SampleBlazor.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext db)
        {
            _context = db;
        }
        public async Task<OrderHeader> CreateAsync(OrderHeader orderHeader)
        {
            orderHeader.OrderDate = DateTime.Now;
            await _context.AddAsync(orderHeader);
            await _context.SaveChangesAsync();
            return orderHeader;
        }

        public async Task<IEnumerable<OrderHeader>> GetAllAsync(string? userId = null)
        {
            if(!string.IsNullOrEmpty(userId))
            {
                return await _context.OrderHeader.Where(u => u.UserId == userId).ToListAsync();
            }
            return await _context.OrderHeader.ToListAsync();
        }

        public async Task<OrderHeader> GetAsync(int id)
        {
            return await _context.OrderHeader.Include(u => u.OrderDetails).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<OrderHeader> UpdateStatusAsync(int orderId, string status)
        {
            var orderHeader = _context.OrderHeader.FirstOrDefault(u => u.Id == orderId);
            
            if(orderHeader != null)
            {
                orderHeader.Status = status;
                await _context.SaveChangesAsync();
            }
            return orderHeader;
        }
    }
}
