using Domain.Entities;

namespace Domain.Interfaces.InterfacesRepositories
{
    public interface IEmployeeRepositiry : IGenericRepository<Employee>
    {
        Task<Employee> GetByUser(string user);
        Task<List<Employee>> GetByFunction(EnumFunctionEmployee function);
    }
}