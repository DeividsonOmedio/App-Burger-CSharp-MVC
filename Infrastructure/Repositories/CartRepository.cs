using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Infrastructure.Configuration;

namespace Infrastructure.Repositories
{
    public class CartRepository(ContextBase context) : GenericRepository<Cart>(context), ICartRepository
    {
    }
}
