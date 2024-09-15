namespace Mvc.Models
{
    public class Checkout
    {
        public List<Cart> CartItems { get; set; }
        public List<Cadastre> Addresses { get; set; }
    }
}
