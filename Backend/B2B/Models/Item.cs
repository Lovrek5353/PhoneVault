namespace PhoneVault.B2B.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public decimal SellPrice { get; set; }
        public int QuantityInStock { get; set; }
        public int CategoryId { get; set; }
    }
}
