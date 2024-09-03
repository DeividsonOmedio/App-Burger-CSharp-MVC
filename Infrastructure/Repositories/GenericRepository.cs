using Domain.Interfaces.InterfacesRepositories;
using Domain.Notifications;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T>(ContextBase context) : IGenericRepository<T> where T : class
    {
        protected readonly ContextBase _context = context;
        protected readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task<Notifies> Add(T obj)
        {
            try
            {
                await _dbSet.AddAsync(obj);
                await _context.SaveChangesAsync();
                return Notifies.Success("Salvo com sucesso!");
            }
            catch (Exception e)
            {
                return Notifies.Error("Erro ao salvar: " + e.Message);
            }
        }

        public async Task<Notifies> Update(T obj)
        {
            try
            {
                _dbSet.Update(obj);
                await _context.SaveChangesAsync();
                return Notifies.Success("Atualizado com sucesso!");
            }
            catch (Exception e)
            {
                return Notifies.Error("Erro ao atualizar: " + e.Message);
            }
        }

        public async Task<Notifies> Delete(T obj)
        {
            try
            {
                _dbSet.Remove(obj);
                await _context.SaveChangesAsync();
                return Notifies.Success("Deletado com sucesso!");
            }
            catch (Exception e)
            {
                return Notifies.Error("Erro ao deletar: " + e.Message);
            }
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
    }
}