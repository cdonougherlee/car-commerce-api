using CarCommerceAPI.Models;


namespace CarCommerceAPI.Interfaces
{
    public interface IVanRepository
    {
        ICollection<Van> GetVans();
        Van GetVan(int id);
        public bool VanExists(int id);
        bool CreateVan(Van van);
        bool UpdateVan(Van van);
        bool DeleteVan(Van van);
        bool Save();
    }
}
