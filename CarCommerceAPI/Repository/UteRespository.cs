using CarCommerceAPI.Data;
using CarCommerceAPI.Interfaces;
using CarCommerceAPI.Models;

namespace CarCommerceAPI.Repository
{
    public class UteRepository: IUteRepository
    {
        private readonly DataContext _context;
        public UteRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Ute> GetUtes()
        {
            return _context.Utes.OrderBy(u => u.Id).ToList();
        }

        public Ute GetUte(int id)
        {
            return _context.Utes.Where(p => p.Id == id).FirstOrDefault();

        }

        public bool UteExists(int id)
        {
            return _context.Utes.Any(c => c.Id == id);
        }

        public bool CreateUte(Ute ute)
        {
            _context.Utes.Add(ute);
            return Save();
        }

        public bool UpdateUte(Ute ute)
        {
            _context.Update(ute);
            return Save();
        }

        public bool DeleteUte(Ute ute)
        {
            _context.Remove(ute);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

