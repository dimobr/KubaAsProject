namespace KubaAsProject.Models
{
    public class Warehouse : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public int OwnerId { get; set; }    
        public WarehouseOwner Owner { get; set; }
    }
}
