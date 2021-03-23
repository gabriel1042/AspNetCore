using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.business.models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.services
{
    public class CityService : BaseService, ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository,
                                 INotificator notificator) : base(notificator)
        {
            _cityRepository = cityRepository;
        }

        public async Task<bool> Create(City city)
        {
            if (!ExecuteValidation(new CityValidation(), city)) return false;

            await _cityRepository.Add(city);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _cityRepository.Remove(id);
            return true;
        }

        public void Dispose()
        {
            _cityRepository?.Dispose();
        }

        public bool Exists(int id)
        {
            return _cityRepository.Any(e => e.Id == id);
        }

        public async Task<List<City>> GetAll()
        {
            return await _cityRepository.GetAll();
        }

        public async Task<City> GetById(int id)
        {
            return await _cityRepository.GetById(id);
        }

        public async Task<bool> Update(City city)
        {
            if (!ExecuteValidation(new CityValidation(), city)) return false;
            await _cityRepository.Update(city);
            return true;
        }
    }
}
