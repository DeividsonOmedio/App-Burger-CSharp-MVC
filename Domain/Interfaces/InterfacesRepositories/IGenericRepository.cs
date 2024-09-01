using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<Notifies> Add(T obj);
        Task<Notifies> Update(T obj);
        Task<Notifies> Delete(T obj);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}