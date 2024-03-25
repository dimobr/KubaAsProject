using KubaAsProject.Models;
using KubaAsProject.Repository;

namespace KubaAsProject.Services.Implementations
{
    public class WarehouseOwnerService : IWarehouseOwnerService
    {
        private readonly IRepository<WarehouseOwner> _warehouseOwnerRepository;  

        public WarehouseOwnerService(IRepository<WarehouseOwner> warehouseOwnerRepository)
        {
            _warehouseOwnerRepository = warehouseOwnerRepository;
        }

        public async Task<IList<WarehouseOwner>> GetAllOwners()
        {
            return await _warehouseOwnerRepository.GetAll();
        }

        public async Task<WarehouseOwner> GetWarehouseOwnerByIdAsync(int id)
        {
            return await _warehouseOwnerRepository.GetByIdAsync(id);
        }

        public async Task AddWarehouseOwnerAsync(WarehouseOwner warehouseOwner)
        {
            await _warehouseOwnerRepository.AddAsync(warehouseOwner);
        }

        public async Task UpdateWarehouseOwnerAsync(WarehouseOwner warehouseOwner)
        {
            await _warehouseOwnerRepository.UpdateAsync(warehouseOwner);
        }

        public async Task DeleteWarehouseOwnerByIdAsync(int id)
        {
            await _warehouseOwnerRepository.DeleteByIdAsync(id);
        }

        public async Task DeleteWarehouseOwnerAsync(WarehouseOwner warehouseOwner)
        {
            await _warehouseOwnerRepository.DeleteAsync(warehouseOwner);
        }
    }
}
