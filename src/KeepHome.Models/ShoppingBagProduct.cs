namespace KeepHome.Models
{
    public class ShoppingBagProduct
    {
        public int ShoppingBagId { get; set; }
        public virtual ShoppingBag ShoppingBag { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}