using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using KubaAsProject.Models;
using KubaAsProject.Models.DtoModels;
using KubaAsProject.Services;

namespace KubaAsProject.Controllers.API
{
    [ApiController]
    [Route("api/{controller}")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        private readonly ILogger<WarehouseController> _logger;
        private readonly IMapper _autoMapper;

        public WarehouseController(IWarehouseService warehouseService,
            ILogger<WarehouseController> logger,
            IMapper autoMapper)
        {
            _warehouseService = warehouseService;
            _logger = logger;
            _autoMapper = autoMapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWarehouse(int id)
        {
            try
            {
                var warehouse = await _warehouseService.GetWarehouseByIdAsync(id);
                if (warehouse is null)
                {
                    return NotFound();
                }

                return Ok(_autoMapper.Map<WarehouseDto>(warehouse));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewWarehouse(WarehouseDto warehouseToAdd)
        {
            if (warehouseToAdd is null)
            {
                return BadRequest();
            }

            await _warehouseService.AddWarehouseAsync(_autoMapper.Map<Warehouse>(warehouseToAdd));

            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateWarehouse(WarehouseDto warehouseToUpdate)
        {
            if (warehouseToUpdate is not null)
            {
                await _warehouseService.UpdateWarehouseAsync(_autoMapper.Map<Warehouse>(warehouseToUpdate));
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWarehouse(int id)
        {
            await _warehouseService.DeleteWarehouseByIdAsync(id);
            return Ok();
        }
    }
}
