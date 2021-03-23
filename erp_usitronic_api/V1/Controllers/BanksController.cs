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
    public class BanksController : MainController
    {
        private readonly IBankService _bankService;

        public BanksController(IBankService bankService,
                                INotificator notificator,
                                IHttpContextAccessor httpContextAccessor,
                                IApiUserService apiUserService) : base(notificator, httpContextAccessor, apiUserService)
        {           
            _bankService = bankService;
        }

        // GET: api/Banks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bank>>> GetBanks()
        {          
            //return await _context.Banks.ToListAsync();
            return await _bankService.GetAll();
        }

        // GET: api/Banks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bank>> GetBank(int id)
        {
            var bank = await _bankService.GetById(id);

            if (bank == null)
            {
                return NotFound();
            }

            return bank;
        }

        // PUT: api/Banks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBank(int id, Bank bank)
        {
            if (id != bank.Id)
            {
                return BadRequest();
            }

            try
            {
                await _bankService.Update(bank);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_bankService.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CustomResponse(bank);
        }

        // POST: api/Banks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bank>> PostBank(Bank bank)
        {
            await _bankService.Create(bank);

            return CustomResponse(bank);
        }

        // DELETE: api/Banks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bank>> DeleteBank(int id)
        {
            var bank = await _bankService.GetById(id);
            if (bank == null)
            {
                return NotFound();
            }

            await _bankService.Delete(bank.Id);

            return CustomResponse(bank);
        }
    }
}
