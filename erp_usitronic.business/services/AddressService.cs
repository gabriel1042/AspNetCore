using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.business.models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.services
{
    public class AddressService : BaseService, IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IPersonService _personService;
        private readonly ICityService _cityService;

        public AddressService(IAddressRepository addressRepository,
                              IPersonService personService,
                              ICityService cityService,
                              INotificator notificator) : base(notificator)
        {
            _addressRepository = addressRepository;
            _personService = personService;
            _cityService = cityService;
    }

        public async Task<bool> Create(Address address)
        {
            if (!ExecuteValidation(new AddressValidation(), address)) return false;
            if (!DependeciesIsValid(address)) return false;

            await _addressRepository.Add(address);
            return true;
        }

        private bool DependeciesIsValid(Address address)
        {
            if (!_personService.Exists(address.PersonId))
            {
                Notify("Não existe uma pessoa com o id informado na propriedade PersonId");
                return false;
            }
            if (!_cityService.Exists(address.CityId))
            {
                Notify("Não existe uma cidade com o id informado na propriedade CityId");
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _addressRepository.Remove(id);
            return true;
        }

        public void Dispose()
        {
            _addressRepository?.Dispose();
        }

        public bool Exists(int id)
        {
            return _addressRepository.Any(e => e.Id == id);
        }

        public async Task<List<Address>> GetAll()
        {
            return await _addressRepository.GetAll();
        }

        public async Task<Address> GetById(int id)
        {
            return await _addressRepository.GetById(id);
        }

        public async Task<bool> Update(Address address)
        {
            if (!ExecuteValidation(new AddressValidation(), address)) return false;
            if (!DependeciesIsValid(address)) return false;

            await _addressRepository.Update(address);
            return true;
        }
    }
}
