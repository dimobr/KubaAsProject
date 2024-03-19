namespace KubaAsProject.Models
{
    public class Item : BaseEntity
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }   
        public string? ItemPriceWithCurrency { get; set; }
        public bool? IsAvailableForShipping { get; set; }
    }
}
