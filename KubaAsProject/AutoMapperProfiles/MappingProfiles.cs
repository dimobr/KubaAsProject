using AutoMapper;
using KubaAsProject.Models;
using KubaAsProject.Models.DtoModels;

namespace KubaAsProject.AutoMapperProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Inventory, InventoryDto>()
                .ReverseMap();

            CreateMap<Item, ItemDto>()
                .ReverseMap();

            CreateMap<Warehouse, WarehouseDto>()
                .ReverseMap();

            CreateMap<WarehouseOwner, WarehouseOwnerDto>()
                .ReverseMap();  
        }
    }
}
