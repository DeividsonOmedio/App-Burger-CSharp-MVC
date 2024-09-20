using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Notifications;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<Employee> GetByEmail(string email);
        Task<List<Employee>> GetByFunction(EnumFunctionEmployee function);
        Task<Notifies> Add(Employee employee);
        Task<Notifies> Update(Employee empoyee);
        Task<Notifies> Delete(int id);
    }
}