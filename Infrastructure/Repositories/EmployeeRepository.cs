using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Interfaces.InterfacesRepositories;
using Infrastructure.Configuration;
using System.Data.Entity;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository(ContextBase context) : GenericRepository<Employee>(context), IEmployeeRepository
    {
        public Task<List<Employee>> GetByFunction(EnumFunctionEmployee function)
        {
            return _dbSet.Where(e => e.Function == function).ToListAsync();
        }

        public Task<Employee> GetByUser(string user)
        {
            return _dbSet.FirstOrDefaultAsync(e => e.User == user);
        }

    }
}