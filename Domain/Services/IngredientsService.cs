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

            return await _ingredientsRepository.Update(result);
        }

        public async Task<IEnumerable<string>> GetMaterialsByProductId(int productId)
        {
            var ingredients = await GetByProductId(productId);
            var materials = new List<string>();

            foreach (var ingredient in ingredients)
            {
                var material = await _materialRepository.GetById(ingredient.MaterialId);
                materials.Add(material.Name);
            }

            return materials;
        }
    }
}