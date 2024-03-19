namespace KubaAsProject.Models
{
    public class Inventory : BaseEntity
    {
        public int? WarehouseId { get; set; }
        public int? ItemQuantity { get; set; }
        public int? ItemId { get; set; }
        public Item? Item { get; set; }
        public Warehouse? Warehouse { get; set; }    
    }
}
