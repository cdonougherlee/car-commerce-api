using CarCommerceAPI.Models;


namespace CarCommerceAPI.Interfaces
{
    public interface IElectricRepository
    {
        ICollection<Electric> GetElectrics();
        Electric GetElectric(int id);
        public bool ElectricExists(int id);
        bool CreateElectric(Electric electric);
        bool UpdatePrice(Electric electric, int price);
        bool DeleteElectric(Electric electric);
        bool Save();
    }
}
