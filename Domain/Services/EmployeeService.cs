using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Interfaces.InterfacesServices;
using Domain.Notifications;

namespace Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        public Task<Notifies> Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Delete(Employee empoyee)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetByFunction(EnumFunctionEmployee function)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByUser(string user)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Update(Employee empoyee)
        {
            throw new NotImplementedException();
        }
    }
}