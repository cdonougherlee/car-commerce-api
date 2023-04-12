
namespace CarCommerceAPI.Models
{
    public class Van: Car
    {
        public int CargoVolume { get; set; }
      
        public new string displayDetails()
        {
            return base.displayDetails() + $" and has {this.CargoVolume}m3 of cargo volume capactiy."; 
        }
    }
}
