using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Infrastructure.Configuration;

namespace Infrastructure.Repositories
{
    public class SaleProductRepository(ContextBase context) : GenericRepository<SaleProduct>(context), ISaleProductRepository
    {
    }
}