using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.DAL.Entities.Checkout
{
    public class CheckoutEntity:BaseEntity
    {
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserEmail { get; set; }
        public string ApplicationUserId { get; set; }
        public long VisaCardNumber { get; set; }
        public string VisaCVV { get; set; }
        public string VisaExpireDate { get; set; }
        public double TotalPrice { get; set; } 
        public DateTime Checkout_Date { get; set; } = DateTime.Now;
    }
}
