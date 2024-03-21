using KubaAsProject.Models;
using KubaAsProject.Repository;

namespace KubaAsProject.Services.Implementations
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IRepository<Warehouse> _warehouseRepository;

        public WarehouseService(IRepository<Warehouse> warehouseRepository) 
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<Warehouse> GetWarehouseByIdAsync(int id)
        {
            return await _warehouseRepository.GetByIdAsync(id);
        }

        public async Task AddWarehouseAsync(Warehouse warehouse)
        {
            await _warehouseRepository.AddAsync(warehouse);
        }

        public async Task UpdateWarehouseAsync(Warehouse warehouse)
        {
            await _warehouseRepository.UpdateAsync(warehouse);
        }

        public async Task DeleteWarehouseByIdAsync(int id)
        {
            await _warehouseRepository.DeleteByIdAsync(id);
        }

        public async Task DeleteWarehouseAsync(Warehouse warehouse)
        {
            await _warehouseRepository.DeleteAsync(warehouse);
        }
    }
}
