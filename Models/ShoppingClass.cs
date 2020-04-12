using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameTracker_release.Models
{
    public class ShoppingClass
    {
        [Key]
        public int ShoppingCartItemId { get; set; }
        public Game Game { get; set; }
        public int Amount { get; set; }
        
        public string ShoppingCartId { get; set; }
    }
}
