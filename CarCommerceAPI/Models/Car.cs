namespace CarCommerceAPI.Models
{
    public class Car
    {
        public int Id { get; private set; }
        public string Brand { get; private set; }  
        public string Model { get; private set; }
        public string Colour { get; private set; } 
        public string Engine { get; private set; } 
        public int NumSeats { get; private set; }

        public int Price { get; private set; }
        public bool Auction { get; private set; }

        public Car( string brand, string model, string colour, string engine, int numSeats, int price, bool auction)
        {
            Brand = brand;
            Model = model;
            Colour = colour;
            Engine = engine;
            NumSeats = numSeats;
            Price = price;
            Auction = auction;
        }

        public string displayDetails()
        {
            string listing = $"{(this.Auction ? $"Starting bid of: {this.Price}" : $"Asking price of: {this.Price}")}";
            string details = $"{this.Brand} {this.Model} of colour {this.Colour}. Features a {this.Engine}, with {this.NumSeats} seats";
            return $"{listing}\n{details}";
        }

        public void updatePrice(int price)
        {
            Price = price;
        }
    }
}
