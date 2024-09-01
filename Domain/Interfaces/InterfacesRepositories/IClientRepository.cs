using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesRepositories
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<Client> GetByName(string name);
        Task<Client> GetByEmail(string email);
        Task<Client> GetByPhone(string phone);
    }
}