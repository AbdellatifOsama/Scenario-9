using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.DAL.Entities.Checkout
{
    public class CartEntity
    {
        public string ApplicationUserId { get; set; }
        public int BookEntityId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public BookEntity BookEntity { get; set; }
    }
}
