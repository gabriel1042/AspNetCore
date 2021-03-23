using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.business.models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.services
{
    public class CompanyService : BaseService, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository,
                                 INotificator notificator) : base(notificator)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> Create(Company company)
        {
            if (!ExecuteValidation(new CompanyValidation(), company)) return false;

            await _companyRepository.Add(company);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _companyRepository.Remove(id);
            return true;
        }

        public void Dispose()
        {
            _companyRepository?.Dispose();
        }

        public bool Exists(int id)
        {
            return _companyRepository.Any(e => e.Id == id);
        }

        public async Task<List<Company>> GetAll()
        {
            return await _companyRepository.GetAll();
        }

        public async Task<Company> GetById(int id)
        {
            return await _companyRepository.GetById(id);
        }

        public async Task<bool> Update(Company company)
        {
            if (!ExecuteValidation(new CompanyValidation(), company)) return false;
            await _companyRepository.Update(company);
            return true;
        }
    }
}
