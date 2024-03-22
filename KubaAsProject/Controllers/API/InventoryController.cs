using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using KubaAsProject.Models;
using KubaAsProject.Models.DtoModels;
using KubaAsProject.Services;

namespace KubaAsProject.Controllers.API
{
    [ApiController]
    [Route("api/{controller}")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly ILogger<InventoryController> _logger;
        private readonly IMapper _autoMapper;

        public InventoryController(IInventoryService inventoryService,
            ILogger<InventoryController> logger,
            IMapper autoMapper) 
        {
            _inventoryService = inventoryService;   
            _logger = logger;
            _autoMapper = autoMapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventory(int id)
        {
            try
            {
                var inventory = await _inventoryService.GetInventoryByIdAsync(id);
                if (inventory is null)
                {
                    return NotFound();
                }

                return Ok(_autoMapper.Map<InventoryDto>(inventory));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(); 
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewInventory([FromBody] InventoryDto inventoryToAdd)
        {
            if (inventoryToAdd is null)
            {
                return BadRequest();
            }

            await _inventoryService.AddInventoryAsync(_autoMapper.Map<Inventory>(inventoryToAdd));

            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateInventory([FromBody] InventoryDto inventoryToUpdate)
        {
            if (IsValidValue(inventoryToUpdate)) 
            {
                await _inventoryService.UpdateInventoryAsync(_autoMapper.Map<Inventory>(inventoryToUpdate));
                return Ok(); 
            } 
            else 
            { 
                return BadRequest(); 
            }
        }

        [HttpDelete]    
        public async Task<IActionResult> DeleteInventory(int id)
        {
            await _inventoryService.DeleteInventoryByIdAsync(id);
            return Ok();
        }

        private static bool IsValidValue(InventoryDto inventory) 
        {
            if (inventory.WarehouseId is not null 
                && inventory.ItemId is not null) return true;

            return false;
        }
    }
}
