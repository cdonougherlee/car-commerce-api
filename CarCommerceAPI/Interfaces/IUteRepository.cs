using CarCommerceAPI.Models;

namespace CarCommerceAPI.Interfaces
{
    public interface IUteRepository
    {
        ICollection<Ute> GetUtes();
        Ute GetUte(int id);
        public bool UteExists(int id);
        bool CreateUte(Ute ute);
        bool UpdateUte(Ute ute);
        bool DeleteUte(Ute ute);
        bool Save();
    }

}
 