using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Domain.Notifications;

namespace Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public Task<Notifies> Add(Client obj)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Delete(Client obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<Client>> GetAll()
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

        public Task<Notifies> Update(Client obj)
        {
            throw new NotImplementedException();
        }
    }
}