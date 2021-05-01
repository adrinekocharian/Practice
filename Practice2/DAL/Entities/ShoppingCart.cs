using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    [Table("ShoppingCart")]
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public int ItemsCount { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedOn { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
