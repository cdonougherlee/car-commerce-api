using CarCommerceAPI.Data;
using CarCommerceAPI.Interfaces;
using CarCommerceAPI.Models;

namespace CarCommerceAPI.Repository
{
    public class VanRepository: IVanRepository
    {
        private readonly DataContext _context;
        public VanRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Van> GetVans()
        {
            return _context.Vans.OrderBy(v => v.Id).ToList();
        }

        public Van GetVan(int id)
        {
            return _context.Vans.Where(p => p.Id == id).FirstOrDefault();
        }

        public bool VanExists(int id)
        {
            return _context.Vans.Any(v => v.Id == id);
        }

        public bool CreateVan(Van van)
        {
            _context.Vans.Add(van);
            return Save();
        }

        public bool UpdateVan(Van van)
        {
            _context.Update(van);
            return Save();
        }

        public bool DeleteVan(Van van)
        {
            _context.Remove(van);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
