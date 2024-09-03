using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        protected readonly Context _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public async Task<Notifies> Add(Client obj)
        {
            try
            {
                await dbSet.AddAsync(obj);
                await _context.SaveChangesAsync();
                return Task.FromResult(new Notifies { Message = "Cadastrado com sucesso!", Success = true });
            }
            catch (Exception e)
            {
                return Task.FromResult(new Notifies { Message = e.Message, Success = false });
            }

        }

        public async Task<Notifies> Update(Client obj)
        {
            try
            {
                _dbSet.Update(obj);
                await _context.SaveChangesAsync();
                return Task.FromResult(new Notifies { Message = "Aualizado com sucesso!", Success = true });
            }
            catch (Exception e)
            {
                return Task.FromResult(new Notifies { Message = e.Message, Success = false });
            }
        }

        public async Task<Notifies> Delete(Client obj)
        {
            try
            {
                _dbSet.Remove(obj);
                await _context.SaveChangesAsync();
                return Task.FromResult(new Notifies { Message = "Deletado com sucesso!", Success = true });
            }

        }

        public Task<List<Client>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetById(int id)
        {
            //realizar busca por id

        }
    }
}