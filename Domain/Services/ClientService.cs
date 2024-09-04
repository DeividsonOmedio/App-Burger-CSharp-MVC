using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Domain.Interfaces.InterfacesServices;
using Domain.Notifications;

namespace Domain.Services
{
    public class ClientService(IClientRepository clientRepository) : IClientService
    {
        private readonly IClientRepository _clientRepository = clientRepository;

        public async Task<Notifies> Add(Client client)
        {
            if (client == null)
                return Notifies.Error("Cliente inválido");

            return await _clientRepository.Add(client);
        }

        public async Task<Notifies> Update(Client client)
        {
            if (client == null)
                return Notifies.Error("Cliente inválido");

            var result = await _clientRepository.GetById(client.Id);
            if (result == null)
                return Notifies.Error("Cliente não encontrado");

            return await _clientRepository.Update(result);
            
        }

        public async Task<Notifies> Delete(int id)
        {
            if (id <= 0)
                return Notifies.Error("Id inválido");

            var result = await _clientRepository.GetById(id);
            if (result == null)
                return Notifies.Error("Cliente não encontrado");

            return await _clientRepository.Delete(result);
            
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _clientRepository.GetAll();
        }

        public async Task<Client> GetById(int id)
        {
            if (id <= 0)
                return null;

            return await _clientRepository.GetById(id);
        }

        public async Task<Client> GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            return await _clientRepository.GetByEmail(email);
        }

        public async Task<Client> GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            return await _clientRepository.GetByName(name);
        }

        public async Task<Client> GetByPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return null;

            return await _clientRepository.GetByPhone(phone);
        }

    }
}