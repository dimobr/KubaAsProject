using KubaAsProject.Models;

namespace KubaAsProject.Services
{
    public interface IItemService
    {
        Task<Item> GetItemByIdAsync(int id);
        Task AddItemAsync(Item inventory);
        Task UpdateItemAsync(Item inventory);
        Task DeleteItemByIdAsync(int id);
        Task DeleteItemAsync(Item inventory);
    }
}
