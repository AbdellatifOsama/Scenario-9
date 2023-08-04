using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_9_Backend.DAL.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string? UserPictureName { get; set; }
        public bool IsTermsAgreed { get; set; }
        public DateTime JoinedDate { get; set; } = DateTime.Now;
    }
}
