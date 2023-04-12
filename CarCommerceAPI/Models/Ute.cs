namespace CarCommerceAPI.Models
{
    public class Ute: Car
    {
        public int TowingCapactity { get; set; }
 

        public new string displayDetails()
        {
            return base.displayDetails() + $" and {this.TowingCapactity}kg of towing capacity.";
        }
    }
}
