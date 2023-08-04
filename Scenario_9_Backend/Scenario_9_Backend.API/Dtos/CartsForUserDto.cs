using Scenario_9_Backend.DAL.Entities;

namespace Scenario_9_Backend.API.Dtos
{
    public class CartsForUserDto
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public BookEntity BookEntity { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
