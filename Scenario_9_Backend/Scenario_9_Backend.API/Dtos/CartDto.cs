namespace Scenario_9_Backend.API.Dtos
{
    public class CartDto
    {
        public string ApplicationUserEmail { get; set; }
        public int BookEntityId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
