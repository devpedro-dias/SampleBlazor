using SampleBlazor.Data;

namespace SampleBlazor.Repository.Interfaces
{
    public interface IShoppingCartRepository
    {
        public Task<bool> UpdateCartAsync(string userId, int productId, int updatedBy);
        public Task<IEnumerable<ShoppingCart>> GetAllAsync(string? userId);
        public Task<bool> ClearCartAsync(string? userId);
        public Task<int> GetTotalCartCountAsync(string? userId);
    }
}
