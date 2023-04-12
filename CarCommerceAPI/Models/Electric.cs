namespace CarCommerceAPI.Models
{
    public class Electric : Car
    {
        public string ChargeType { get; private set; }

        public Electric(string brand, string model, string colour, string engine, int numSeats, int price, bool auction, string chargeType) : base( brand, model, colour, engine, numSeats, price, auction)
        {
            ChargeType = chargeType;
        }


        public new string displayDetails()
        {
            return base.displayDetails() + $" and uses a {this.ChargeType} charger.";
        }
    }
}
