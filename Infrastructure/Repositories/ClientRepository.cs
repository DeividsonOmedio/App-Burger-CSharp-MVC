using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ClientRepository(ContextBase context) : GenericRepository<Client>(context), IClientRepository
    {
        public async Task<Client> GetByEmail(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Client> GetByName(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<Client> GetByPhone(string phone)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.PhoneNumber == phone);
        }
    }
}