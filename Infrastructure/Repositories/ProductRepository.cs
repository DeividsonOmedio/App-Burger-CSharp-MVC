using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Infrastructure.Configuration;

namespace Infrastructure.Repositories
{
    public class ProductRepository(ContextBase context) : GenericRepository<Product>(context), IProductRepository
    {
        
    }
}