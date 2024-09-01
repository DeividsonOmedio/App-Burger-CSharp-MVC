using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesRepositories
{
    public interface IEmployeeRepositiry : IGenericRepository<Employee>
    {
        Task<Employee> GetByUser(string user);
        Task<List<Employee>> GetByFunction(EnumFunctionEmployee function);
    }
}