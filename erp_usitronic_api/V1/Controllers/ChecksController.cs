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
    public class ChecksController : MainController
    {
        private readonly ICheckService _checkService;

        public ChecksController(ICheckService checkService,
                                INotificator notificator,
                                IHttpContextAccessor httpContextAccessor,
                                IApiUserService apiUserService) : base(notificator, httpContextAccessor, apiUserService)
        {
            _checkService = checkService;
        }

        // GET: api/Checks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Check>>> GetChecks()
        {
            //return await _context.Checks.ToListAsync();
            return await _checkService.GetAll();
        }

        // GET: api/Checks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Check>> GetCheck(int id)
        {
            var check = await _checkService.GetById(id);

            if (check == null)
            {
                return NotFound();
            }

            return check;
        }

        // PUT: api/Checks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheck(int id, Check check)
        {
            if (id != check.Id)
            {
                return BadRequest();
            }

            try
            {
                await _checkService.Update(check);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_checkService.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CustomResponse(check);
        }

        // POST: api/Checks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Check>> PostCheck(Check check)
        {
            await _checkService.Create(check);

            return CustomResponse(check);
        }

        // DELETE: api/Checks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Check>> DeleteCheck(int id)
        {
            var check = await _checkService.GetById(id);
            if (check == null)
            {
                return NotFound();
            }

            await _checkService.Delete(check.Id);

            return CustomResponse(check);
        }
    }
}
