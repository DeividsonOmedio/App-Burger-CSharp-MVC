using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Interfaces.InterfacesRepositories;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SaleRepository(ContextBase context) : GenericRepository<Sale>(context), ISaleRepository
    {
     
        public async Task<List<Sale>> GetByClient(int idClient)
        {
            return await _dbSet.Where(s => s.ClientId == idClient).ToListAsync();
        }

        public async Task<List<Sale>> GetByDate(DateTime date)
        {
           return await _dbSet.Where(s => s.SaleDate == date).ToListAsync();
        }

        public async Task<List<Sale>> GetByEmployee(int idEmployee)
        {
            return await _dbSet.Where(s => s.EmployeeId == idEmployee).ToListAsync();
        }

        public async Task<List<Sale>> GetByStatusPayment(EnumStatusPayment statusPayment)
        {
            return await _dbSet.Where(s => s.StatusPayment == statusPayment).ToListAsync();
        }

        public async Task<List<Sale>> GetByStatusSale(EnumStatusSale statusSale)
        {
            return await _dbSet.Where(s => s.StatusSale == statusSale).ToListAsync();
        }

        public async Task<List<Sale>> GetByTypePayment(EnumTypePayment typePayment)
        {
            return await _dbSet.Where(s => s.TypePayment == typePayment).ToListAsync();
        }

    }
}