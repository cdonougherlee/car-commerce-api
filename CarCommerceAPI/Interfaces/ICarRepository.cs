using CarCommerceAPI.Models;

namespace CarCommerceAPI.Interfaces
{
    public interface ICarRepository
    {
        ICollection<Car> GetCars();
        Car GetCar(int id);
        public bool CarExists(int id);
    }
}
