using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IEmpoyeeService
    {
        Task<IEnumerable<Empoyee>> GetAll();
        Task<Empoyee> GetById(int id);
        Task<Empoyee> GetByUser(string user);
        Task<List<Empoyee>> GetByFunction(EnumFunctionEmployee function);
        Task<Notifies> Add(Empoyee employee);
        Task<Notifies> Update(Empoyee empoyee);
        Task<Notifies> Delete(Empoyee empoyee);
    }
}