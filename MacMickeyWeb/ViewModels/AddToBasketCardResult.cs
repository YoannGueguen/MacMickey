namespace MacMickeyWeb.ViewModels
{
    public class AddToBasketCardResult
    {
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        public int CartItemCount { get; set; }

        public decimal CartAmount { get; set; }
    }
}
