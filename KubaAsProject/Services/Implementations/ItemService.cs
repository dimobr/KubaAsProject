using KubaAsProject.Models;
using KubaAsProject.Repository;

namespace KubaAsProject.Services.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IRepository<Item> _itemRepository;

        public ItemService(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _itemRepository.GetByIdAsync(id);  
        }

        public async Task AddItemAsync(Item item)
        {
            await _itemRepository.AddAsync(item);
        }

        public async Task UpdateItemAsync(Item item)
        {
            await _itemRepository.UpdateAsync(item);
        }

        public async Task DeleteItemByIdAsync(int id)
        {
            await _itemRepository.DeleteByIdAsync(id);
        }

        public async Task DeleteItemAsync(Item item)
        {
            await _itemRepository.DeleteAsync(item);
        }
    }
}
