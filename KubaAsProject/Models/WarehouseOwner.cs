﻿using System.ComponentModel.DataAnnotations;

namespace KubaAsProject.Models
{
    public class WarehouseOwner : BaseEntity
    {
        public string Name {  get; set; }
        public bool? IsBusiness { get; set; }
        public string? ContactPerson { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }

        public ICollection<Warehouse>? Warehouses { get; set; }
    }
}
