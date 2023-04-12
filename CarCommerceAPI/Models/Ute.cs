namespace CarCommerceAPI.Models
{
    public class Ute: Car
    {
        public int TowingCapactity { get; set; }

        public Ute(string brand, string model, string colour, string engine, int numSeats, int price, bool auction, int towingCapactity) : base(brand, model, colour, engine, numSeats, price, auction)
        {
            TowingCapactity = towingCapactity;
        }



        public new string displayDetails()
        {
            return base.displayDetails() + $" and {this.TowingCapactity}kg of towing capacity.";
        }
    }
}
