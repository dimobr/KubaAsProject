namespace KubaAsProject.Models.DtoModels
{
    public class ItemDto
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string? ItemPriceWithCurrency { get; set; }
        public bool? IsAvailableForShipping { get; set; }
    }
}
