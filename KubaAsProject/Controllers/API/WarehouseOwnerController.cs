﻿using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using KubaAsProject.Models;
using KubaAsProject.Models.DtoModels;
using KubaAsProject.Services;
using KubaAsProject.Services.Implementations;

namespace KubaAsProject.Controllers.API
{
    [ApiController]
    [Route("api/{controller}")]
    public class WarehouseOwnerController : ControllerBase
    {
        private readonly IWarehouseOwnerService _warehouseOwnerService;
        private readonly ILogger<WarehouseOwnerController> _logger;
        private readonly IMapper _autoMapper;

        public WarehouseOwnerController(IWarehouseOwnerService warehouseOwnerService,
            ILogger<WarehouseOwnerController> logger,
            IMapper autoMapper)
        {
            _warehouseOwnerService = warehouseOwnerService;
            _logger = logger;
            _autoMapper = autoMapper;
        }

        [HttpGet("getAllOwners")]
        public async Task<IActionResult> GetAllOwners()
        {
            try
            {
                var owners = await _warehouseOwnerService.GetAllOwners();
                if (owners is null)
                {
                    return NotFound();
                }

                List<WarehouseOwnerDto> warehouseOwners = new();
                foreach (var owner in owners)
                {
                    warehouseOwners.Add(new WarehouseOwnerDto() 
                    {
                        Name = owner.Name,
                        City = owner.City,  
                        ContactPerson = owner.ContactPerson,    
                        IsBusiness = owner.IsBusiness ?? false,
                        Country = owner.Country,    
                        PhoneNumber = owner.PhoneNumber, 
                        PostalCode = owner.PostalCode,  
                        EmailAddress = owner.EmailAddress,
                        Region = owner.Region,
                        Street = owner.Street            
                    });
                }

                return Ok(warehouseOwners);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("getOwner/{id}")]
        public async Task<IActionResult> GetWarehouseOwner(int id)
        {
            try
            {
                var owner = await _warehouseOwnerService.GetWarehouseOwnerByIdAsync(id);
                if (owner is null)
                {
                    return NotFound();
                }

                return Ok(_autoMapper.Map<WarehouseOwnerDto>(owner));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("addOwner")]
        public async Task<IActionResult> AddWarehouseOwner([FromBody] WarehouseOwnerDto ownerToAdd)
        {
            if (ownerToAdd is null)
            {
                return BadRequest();
            }

            await _warehouseOwnerService.AddWarehouseOwnerAsync(_autoMapper.Map<WarehouseOwner>(ownerToAdd));

            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateWarehouse([FromBody] WarehouseOwnerDto ownerToUpdate)
        {
            if (ownerToUpdate is not null)
            {
                await _warehouseOwnerService.UpdateWarehouseOwnerAsync(_autoMapper.Map<WarehouseOwner>(ownerToUpdate));
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWarehouseOwner(int id)
        {
            await _warehouseOwnerService.DeleteWarehouseOwnerByIdAsync(id);
            return Ok();
        }
    }
}
