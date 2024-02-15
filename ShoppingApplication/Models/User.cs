using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApplication.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = " Your Name:")]
        [Required(ErrorMessage = "its a compulsory field")]
        [StringLength(25, MinimumLength = 1)]
        public string Name { get; set; }

        [Display(Name = "Email ID:")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]   
        public string Email { get; set; }

        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "its a compulsory field")]
        public string Password { get; set; }

        [Display(Name = "Phone Number:")]
        [Required(ErrorMessage = "its a compulsory field")]
        [StringLength(10, MinimumLength = 1)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Address: ")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}