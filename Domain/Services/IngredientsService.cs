using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Domain.Interfaces.InterfacesServices;
using Domain.Notifications;

namespace Domain.Services
{
    public class IngredientsService(IIngredientsRepository ingredientsRepository, IMaterialRepository materialRepository) : IIngredientsService
    {
        private readonly IIngredientsRepository _ingredientsRepository = ingredientsRepository;
        private readonly IMaterialRepository _materialRepository = materialRepository;

        public async Task<Notifies> Add(Ingredients ingredients)
        {
            if (ingredients == null)
                return Notifies.Error("Ingrediente inválido");

            var result =  await _ingredientsRepository.GetByProductId(ingredients.ProductId);
            if (result.Any(e => e.MaterialId == ingredients.MaterialId))
                return Notifies.Error("Este material já foi adicionado ao produto.");

            return await _ingredientsRepository.Add(ingredients);
        }

        public async Task<Notifies> Delete(int id)
        {
            if (id <= 0)
                return Notifies.Error("Id inválido");

            var result = await _ingredientsRepository.GetById(id);
            if (result == null)
                return Notifies.Error("Ingrediente não encontrado");

            return await _ingredientsRepository.Delete(result);
        }

        public async Task<IEnumerable<Ingredients>> GetByMaterialId(int materialId)
        {
            return await _ingredientsRepository.GetByMaterialId(materialId);
        }

        public async Task<IEnumerable<Ingredients>> GetByProductId(int productId)
        { 
            return await _ingredientsRepository.GetByProductId(productId);
        }

        public async Task<Notifies> Update(Ingredients ingredients)
        {
            if (ingredients == null)
                return Notifies.Error("Ingrediente inválido");

            var result = await _ingredientsRepository.GetById(ingredients.Id);
            if (result == null)
                return Notifies.Error("Ingrediente não encontrado");

            result.Amount = ingredients.Amount;

            return await _ingredientsRepository.Update(result);
        }

        //GetByMaterialIdByProductId
        public async Task<Ingredients> GetByMaterialIdByProductId(int materialId, int productId)
        {
            return await _ingredientsRepository.GetByMaterialIdByProductId(materialId, productId);
        }

        public async Task<Dictionary<string, decimal>> GetMaterialsByProductId(int productId)
        {
            var ingredients = await GetByProductId(productId);
            var materialDictionary = new Dictionary<string, decimal>();

            foreach (var ingredient in ingredients)
            {
                var material = await _materialRepository.GetById(ingredient.MaterialId);
                materialDictionary.Add(material.Name, ingredient.Amount);
            }
                
            return materialDictionary;
        }
    }
}