using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.business.models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.services
{
    public class SupplierService : BaseService, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IPersonService _personService;

        public SupplierService(ISupplierRepository supplierRepository,
                               IPersonService personService,
                                 INotificator notificator) : base(notificator)
        {
            _supplierRepository = supplierRepository;
            _personService = personService;
        }

        public async Task<bool> Create(Supplier supplier)
        {
            if (!ExecuteValidation(new SupplierValidation(), supplier)) return false;
            if (!DependeciesIsValid(supplier)) return false;

            await _supplierRepository.Add(supplier);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _supplierRepository.Remove(id);
            return true;
        }

        public void Dispose()
        {
            _supplierRepository?.Dispose();
        }

        public bool Exists(int id)
        {
            return _supplierRepository.Any(e => e.Id == id);
        }

        public async Task<List<Supplier>> GetAll()
        {
            return await _supplierRepository.GetAll();
        }

        public async Task<Supplier> GetById(int id)
        {
            return await _supplierRepository.GetById(id);
        }

        public async Task<bool> Update(Supplier supplier)
        {
            if (!ExecuteValidation(new SupplierValidation(), supplier)) return false;
            if (!DependeciesIsValid(supplier)) return false;

            await _supplierRepository.Update(supplier);
            return true;
        }

        private bool DependeciesIsValid(Supplier supplier)
        {
            if (!_personService.Exists(supplier.PersonId))
            {
                Notify("Não existe uma pessoa com o id informado na propriedade PersonId");
                return false;
            }
            return true;
        }
    }
}
