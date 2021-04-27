using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookbookiev11.Models
{
    public class ShoppingCartItem
    {   
        [Key]
        public int CartItemId { get; set;}
        public BookModel book { get; set; }
        public int amount { get; set; }
        public string ShoppingCartId { get; set; }

    }
}
