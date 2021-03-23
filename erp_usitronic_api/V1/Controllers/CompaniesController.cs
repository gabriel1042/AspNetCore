using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using erp_usitronic.business.models;
using erp_usitronic.business.interfaces;
using erp_usitronic.api.Controllers;
using Microsoft.AspNetCore.Http;

namespace erp_usitronic.api.V1.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CompaniesController : MainController
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService,
                                INotificator notificator,
                                IHttpContextAccessor httpContextAccessor,
                                IApiUserService apiUserService) : base(notificator, httpContextAccessor, apiUserService)
        {
            _companyService = companyService;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            //return await _context.Companies.ToListAsync();
            return await _companyService.GetAll();
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _companyService.GetById(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            try
            {
                await _companyService.Update(company);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_companyService.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CustomResponse(company);
        }

        // POST: api/Companies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            await _companyService.Create(company);

            return CustomResponse(company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Company>> DeleteCompany(int id)
        {
            var company = await _companyService.GetById(id);
            if (company == null)
            {
                return NotFound();
            }

            await _companyService.Delete(company.Id);

            return CustomResponse(company);
        }
    }
}
