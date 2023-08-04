namespace Scenario_9_Backend.API.Dtos
{
    public class CheckoutDto
    {
        public string ApplicationUserEmail { get; set; }
        public long VisaCardNumber { get; set; }
        public int VisaCVV { get; set; }
        public int VisaExpireDate { get; set; }
        public double TotalPrice { get; set; }

    }
}
