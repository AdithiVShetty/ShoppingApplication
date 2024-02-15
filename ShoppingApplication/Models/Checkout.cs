using System.Collections.Generic;

namespace ShoppingApplication.Models
{
    public class Checkout
    {
        public List<CartItem> CartItems { get; set; }
        //public Product Product { get; set; }
        public User User { get; set; }
        public decimal TotalAmount { get; set; }
    }
}