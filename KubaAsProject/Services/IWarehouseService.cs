using KubaAsProject.Models;

namespace KubaAsProject.Services
{
    public interface IWarehouseService
    {
        Task<Warehouse> GetWarehouseByIdAsync(int id);
        Task AddWarehouseAsync(Warehouse warehouse);
        Task UpdateWarehouseAsync(Warehouse warehouse);
        Task DeleteWarehouseByIdAsync(int id);
        Task DeleteWarehouseAsync(Warehouse warehouse);
    }
}
