using KubaAsProject.Models;

namespace KubaAsProject.Services
{
    public interface IInventoryService
    {
        Task<Inventory> GetInventoryByIdAsync(int id);
        Task AddInventoryAsync(Inventory inventory);
        Task UpdateInventoryAsync(Inventory inventory);
        Task DeleteInventoryByIdAsync(int id);
        Task DeleteInventoryAsync(Inventory inventory);
    }
}
