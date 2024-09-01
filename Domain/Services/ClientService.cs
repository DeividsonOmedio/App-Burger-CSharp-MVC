using Domain.Entities;
using Domain.Interfaces.InterfacesServices;
using Domain.Notifications;

namespace Domain.Services
{
    public class ClientService : IClientService
    {
        public Task<Notifies> Add(Client client)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Delete(Client client)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetByPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Update(Client client)
        {
            throw new NotImplementedException();
        }
    }
}