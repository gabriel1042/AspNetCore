using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.business.models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.services
{
    public class StateService : BaseService, IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository,
                                 INotificator notificator) : base(notificator)
        {
            _stateRepository = stateRepository;
        }

        public async Task<bool> Create(State state)
        {
            if (!ExecuteValidation(new StateValidation(), state)) return false;

            await _stateRepository.Add(state);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _stateRepository.Remove(id);
            return true;
        }

        public void Dispose()
        {
            _stateRepository?.Dispose();
        }

        public bool Exists(int id)
        {
            return _stateRepository.Any(e => e.Id == id);
        }

        public async Task<List<State>> GetAll()
        {
            return await _stateRepository.GetAll();
        }

        public async Task<State> GetById(int id)
        {
            return await _stateRepository.GetById(id);
        }

        public async Task<bool> Update(State state)
        {
            if (!ExecuteValidation(new StateValidation(), state)) return false;
            await _stateRepository.Update(state);
            return true;
        }
    }
}
