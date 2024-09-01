using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Interfaces.InterfacesRepositories;
using Domain.Notifications;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<Notifies> Add(Employee obj)
        {
            throw new NotImplementedException();
        }

        public Task<Notifies> Delete(Employee obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAll()
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

        public Task<Notifies> Update(Employee obj)
        {
            throw new NotImplementedException();
        }
    }
}