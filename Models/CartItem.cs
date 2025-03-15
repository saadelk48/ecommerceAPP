namespace ecommerceAPP.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string Nom { get; set; }
        public string ImagePath { get; set; }
        public double Prix { get; set; }
        public int Quantity { get; set; }
    }
}
