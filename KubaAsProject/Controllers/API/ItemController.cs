using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using KubaAsProject.Models;
using KubaAsProject.Models.DtoModels;
using KubaAsProject.Services;

namespace KubaAsProject.Controllers.API
{
    [ApiController]
    [Route("api/{controller}")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly ILogger<ItemController> _logger;
        private readonly IMapper _autoMapper;

        public ItemController(IItemService itemService,
            ILogger<ItemController> logger,
            IMapper autoMapper)
        {
            _itemService = itemService;
            _logger = logger;
            _autoMapper = autoMapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            try
            {
                var item = await _itemService.GetItemByIdAsync(id);
                if (item is null)
                {
                    return NotFound();
                }

                return Ok(_autoMapper.Map<ItemDto>(item));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(ItemDto itemToAdd)
        {
            if (itemToAdd is null)
            {
                return BadRequest();
            }

            await _itemService.AddItemAsync(_autoMapper.Map<Item>(itemToAdd));

            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateItem(ItemDto itemToUpdate)
        {
            if (itemToUpdate is not null)
            {
                await _itemService.UpdateItemAsync(_autoMapper.Map<Item>(itemToUpdate));
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _itemService.DeleteItemByIdAsync(id);
            return Ok();
        }
    }
}
