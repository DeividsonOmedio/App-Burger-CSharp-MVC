using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Domain.Interfaces.InterfacesServices;
using Domain.Notifications;

namespace Domain.Services
{
    public class MaterialService(IMaterialRepository materialRepository) : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository = materialRepository;
        public async Task<Notifies> Add(Material material)
        {
            if (material == null)
                return Notifies.Error("Material inválido");

            return await _materialRepository.Add(material);
        }

        public async Task<Notifies> Delete(int id)
        {
            if (id <= 0)
                return Notifies.Error("Id inválido");

            var result = await _materialRepository.GetById(id);
            if (result == null)
                return Notifies.Error("Material não encontrado");

            return await _materialRepository.Delete(result);
        }

        public async Task<IEnumerable<Material>> GetAll()
        {
            return await _materialRepository.GetAll();
        }

        public async Task<IEnumerable<Material>> GetByAmount(decimal amount)
        {
            return await _materialRepository.GetByAmount(amount);
        }

        public async Task<Material> GetById(int id)
        {
            if (id <= 0)
                return null;

            return await _materialRepository.GetById(id);
        }

        public async Task<IEnumerable<Material>> GetByMinimumQuantity(decimal minimumQuantity)
        {
            return await _materialRepository.GetByMinimumQuantity(minimumQuantity);
        }

        public async Task<IEnumerable<Material>> GetByPurchasePrice(decimal purchasePrice)
        {
            return await _materialRepository.GetByPurchasePrice(purchasePrice);
        }

        // getByName
        public async Task<Material> GetByName(string name)
        {
            return await _materialRepository.GetByName(name);
        }

        public async Task<Notifies> Update(Material material)
        {
            if (material == null)
                return Notifies.Error("Material inválido");

            var result = await _materialRepository.GetById(material.Id);

            if (result == null)
                return Notifies.Error("Material não encontrado");

            result.Name = material.Name;
            result.Amount = material.Amount;
            result.MinimumQuantity = material.MinimumQuantity;
            result.PurchasePrice = material.PurchasePrice;

            return await _materialRepository.Update(result);
        }
    }
}