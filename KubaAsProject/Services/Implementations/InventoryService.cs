using System.Threading.Tasks;
using KubaAsProject.Models;
using KubaAsProject.Repository;

namespace KubaAsProject.Services.Implementations
{
    public class InventoryService : IInventoryService
    {
        private readonly IRepository<Inventory> _inventoryRepository;

        public InventoryService(IRepository<Inventory> inventoryRepository) 
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            return await _inventoryRepository.GetByIdAsync(id);
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            await _inventoryRepository.AddAsync(inventory);  
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            await _inventoryRepository.UpdateAsync(inventory);
        }

        public async Task DeleteInventoryByIdAsync(int id)
        {
            await _inventoryRepository.DeleteByIdAsync(id);
        }

        public async Task DeleteInventoryAsync(Inventory inventory)
        {
            await _inventoryRepository.DeleteAsync(inventory);
        }
    }
}
