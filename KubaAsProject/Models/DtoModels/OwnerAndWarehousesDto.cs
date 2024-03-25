namespace KubaAsProject.Models.DtoModels
{
    public class OwnerAndWarehousesDto
    {
        public string Name { get; set; }
        public bool? IsBusiness { get; set; }
        public string? ContactPerson { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDto Address { get; set; } 
        public List<WarehouseDto> Warehouses { get; set; }
    }
}
