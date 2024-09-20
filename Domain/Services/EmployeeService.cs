using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Interfaces.InterfacesRepositories;
using Domain.Interfaces.InterfacesServices;
using Domain.Notifications;

namespace Domain.Services
{
    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        public async Task<Notifies> Add(Employee employee)
        {
            if (employee == null)
                return Notifies.Error("Funcionário inválido");

            return await _employeeRepository.Add(employee);
        }

        public async Task<Notifies> Delete(int id)
        {
            if (id <= 0)
                return Notifies.Error("Id inválido");

            var result = await _employeeRepository.GetById(id);
            if (result == null)
                return Notifies.Error("Funcionário não encontrado");

            return await _employeeRepository.Delete(result);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _employeeRepository.GetAll();
        }

        public async Task<List<Employee>> GetByFunction(EnumFunctionEmployee function)
        {
            return await _employeeRepository.GetByFunction(function);
        }

        public async Task<Employee> GetById(int id)
        {
            if (id <= 0)
                return null;

            return await _employeeRepository.GetById(id);
        }

        public async Task<Employee> GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            return await _employeeRepository.GetByEmail(email);
        }

        public async Task<Notifies> Update(Employee empoyee)
        {
            if (empoyee == null)
                return Notifies.Error("Funcionário inválido");

            var result = await _employeeRepository.GetById(empoyee.Id);
            if (result == null)
                return Notifies.Error("Funcionário não encontrado");

            result.Name = empoyee.Name;
            result.Function = empoyee.Function;

            return await _employeeRepository.Update(result);
        }
    }
}