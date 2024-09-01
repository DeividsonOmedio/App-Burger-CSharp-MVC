using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetById(int id);
        Task<Client> GetByName(string name);
        Task<Client> GetByEmail(string email);
        Task<Client> GetByPhone(string phone);
        Task<Notifies> Add(Client client);
        Task<Notifies> Update(Client client);
        Task<Notifies> Delete(Client client);
    }
}