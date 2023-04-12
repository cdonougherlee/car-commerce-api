using CarCommerceAPI.Data;
using CarCommerceAPI.Interfaces;
using CarCommerceAPI.Models;

namespace CarCommerceAPI.Repository
{
    public class CarRepository: ICarRepository 
    {
        private readonly DataContext _context;
        public CarRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Car> GetCars()
        {
            return _context.Cars.OrderBy(c => c.Id).ToList();
        }

        public Car GetCar(int id)
        {
            return _context.Cars.Where(p => p.Id == id).FirstOrDefault();
  
        }

        public bool CarExists(int id)
        {
            return _context.Cars.Any(c => c.Id == id);
        }
    }
}
