using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StripeApp.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; } // Link to ApplicationUser

        public List<CartItem> Items { get; set; }

        [NotMapped]
        public decimal TotalAmount => Items?.Sum(i => i.Price * i.Quantity) ?? 0;
    }


}
