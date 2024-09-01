using Domain.Entities;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> GetByName(string name);

    }
}