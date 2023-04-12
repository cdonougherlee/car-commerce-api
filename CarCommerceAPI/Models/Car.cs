namespace CarCommerceAPI.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }  
        public string Model { get; set; }
        public string Colour { get; set; } 
        public string Engine { get; set; } 
        public int NumSeats { get; set; }  
        public int Price { get; set; }
        public bool Auction { get; set; }

       
        public string displayDetails()
        {
            string listing = $"{(this.Auction ? $"Starting bid of: {this.Price}" : $"Asking price of: {this.Price}")}";
            string details = $"{this.Brand} {this.Model} of colour {this.Colour}. Features a {this.Engine}, with {this.NumSeats} seats";
            return $"{listing}\n{details}";
        }

        public Car updatePrice(int Price)
        {
            this.Price = Price;
            return this;
        }

        public Car updatePrice(int Price, bool Auction)
        {
            updatePrice(Price);
            this.Auction = Auction;
            return this;
        }
    }
}
