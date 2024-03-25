﻿using KubaAsProject.Models;

namespace KubaAsProject.Services
{
    public interface IWarehouseOwnerService
    {
        Task<IList<WarehouseOwner>> GetAllOwners();
        Task<WarehouseOwner> GetWarehouseOwnerByIdAsync(int id);
        Task AddWarehouseOwnerAsync(WarehouseOwner warehouseOwner);
        Task UpdateWarehouseOwnerAsync(WarehouseOwner warehouseOwner);
        Task DeleteWarehouseOwnerByIdAsync(int id);
        Task DeleteWarehouseOwnerAsync(WarehouseOwner warehouseOwner);
    }
}
