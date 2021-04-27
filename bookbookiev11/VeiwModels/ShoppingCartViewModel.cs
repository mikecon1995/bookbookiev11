using bookbookiev11.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookbookiev11.VeiwModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartRepo ShoppingCart { get; set; }
        public int ShoppingCartTotal { get; set; }

    }
}
