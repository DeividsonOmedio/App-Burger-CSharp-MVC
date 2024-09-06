using Domain.Entities;
using Domain.Interfaces.InterfacesRepositories;
using Domain.Interfaces.InterfacesServices;
using Domain.Notifications;

namespace Domain.Services
{
    public class AddressService(IAddressRepository addressRepository) : IAddressServices
    {
        private readonly IAddressRepository _addressRepository = addressRepository;

        public async Task<Notifies> Add(Address address)
        {
            if (address == null)
               return Notifies.Error("Address is required");

            if (string.IsNullOrEmpty(address.Street))
                return Notifies.Error("Street is required");

            if (string.IsNullOrEmpty(address.City))
                return Notifies.Error("City is required");

            if (string.IsNullOrEmpty(address.State))
                return Notifies.Error("State is required");

            if (address.Number <= 0)
                return await _addressRepository.Add(address);

            return await _addressRepository.Add(address);

        }

        public async Task<Notifies> Delete(int id)
        {
            if (id <= 0)
                return Notifies.Error("Id is required");

            var result = await _addressRepository.GetById(id);
            
            if (result != null)
                return Notifies.Error("Address not found");

            return await _addressRepository.Delete(result);
        }

        public async Task<List<Address>> GetAll()
        {
            return await _addressRepository.GetAll();
        }

        public async Task<Address> GetById(int id)
        {
            return await _addressRepository.GetById(id);
        }

        public async Task<Notifies> Update(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
