using System.ComponentModel.DataAnnotations;

namespace Scenario_9_Backend.API.Dtos
{
    public class ContactDto
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(2, ErrorMessage = "The Minimum Length is 2")]
        public string Message { get; set; }
    }
}
