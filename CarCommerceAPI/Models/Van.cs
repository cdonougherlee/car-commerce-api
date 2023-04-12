
namespace CarCommerceAPI.Models
{
    public class Van: Car
    {
        public int CargoVolume { get; set; }

        public Van(string brand, string model, string colour, string engine, int numSeats, int price, bool auction, int cargoVolume) : base(brand, model, colour, engine, numSeats, price, auction)
        {
            CargoVolume = cargoVolume;
        }


        public new string displayDetails()
        {
            return base.displayDetails() + $" and has {this.CargoVolume}m3 of cargo volume capactiy."; 
        }
    }
}
