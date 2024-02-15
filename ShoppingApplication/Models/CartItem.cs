using System.ComponentModel.DataAnnotations;

namespace ShoppingApplication.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}