using CarCommerceAPI.Data;
using CarCommerceAPI.Interfaces;
using CarCommerceAPI.Models;

namespace CarCommerceAPI.Repository
{
    public class ElectricRepository: IElectricRepository
    {
        private readonly DataContext _context;
        public ElectricRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Electric> GetElectrics()
        {
            return _context.Electrics.OrderBy(u => u.Id).ToList();
        }

        public Electric GetElectric(int id)
        {
            return _context.Electrics.Where(p => p.Id == id).FirstOrDefault();

        }

        public bool ElectricExists(int id)
        {
            return _context.Electrics.Any(c => c.Id == id);
        }

        public bool CreateElectric(Electric electric)
        {
            _context.Electrics.Add(electric);
            return Save();
        }

        public bool UpdatePrice(Electric electric, int price)
        {
            electric.updatePrice(price);
            return Save();
        }

        public bool DeleteElectric(Electric electric)
        {
            _context.Remove(electric);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
