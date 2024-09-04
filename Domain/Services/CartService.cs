using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Domain.Interfaces.InterfacesServices;
using Domain.Notifications;

namespace Domain.Services
{
    public class CartService(ICartRepository cartRepository) : ICartService
    {
        private readonly ICartRepository _cartRepository = cartRepository;

        public async Task<Notifies> Add(Cart cart)
        {
            if (cart == null)
                return Notifies.Error("Vazio");
            
            return await _cartRepository.Add(cart);
        }

        public async Task<Notifies> Update(Cart cart)
        {
            if (cart == null)
                return Notifies.Error("Vazio");

            var result = await GetById(cart.Id);

            if (result == null)
                return Notifies.Error("Id não encontrado");

            return await _cartRepository.Update(result);
        }

        public async Task<Notifies> Delete(int id)
        {
            if (id <= 0)
                return Notifies.Error("Vazio");

            var result = await GetById(id);

            if (result == null)
                return Notifies.Error("Id não encontrado");

            return await _cartRepository.Delete(result);
        }

        public async Task<Cart> GetById(int id)
        {
            return await _cartRepository.GetById(id);
        }

    }
}
