using Domain.Entities;
using Domain.Entities.Enums;

namespace Domain.Interfaces.InterfacesRepositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee> GetByEmail(string email);
        Task<List<Employee>> GetByFunction(EnumFunctionEmployee function);
    }
}