namespace CarCommerceAPI.Models
{
    public class Electric : Car
    {
        
         public string ChargeType { get; set; }

        public new string displayDetails()
        {
            return base.displayDetails() + $" and uses a {this.ChargeType} charger.";
        }
    }
}
