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
    public class TelephonesController : MainController
    {
        private readonly ITelephoneService _telephoneService;

        public TelephonesController(ITelephoneService telephoneService,
                                INotificator notificator,
                                IHttpContextAccessor httpContextAccessor,
                                IApiUserService apiUserService) : base(notificator, httpContextAccessor, apiUserService)
        {
            _telephoneService = telephoneService;
        }

        // GET: api/Telephones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telephone>>> GetTelephones()
        {
            //return await _context.Telephones.ToListAsync();
            return await _telephoneService.GetAll();
        }

        // GET: api/Telephones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Telephone>> GetTelephone(int id)
        {
            var telephone = await _telephoneService.GetById(id);

            if (telephone == null)
            {
                return NotFound();
            }

            return telephone;
        }

        // PUT: api/Telephones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelephone(int id, Telephone telephone)
        {
            if (id != telephone.Id)
            {
                return BadRequest();
            }

            try
            {
                await _telephoneService.Update(telephone);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_telephoneService.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CustomResponse(telephone);
        }

        // POST: api/Telephones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Telephone>> PostTelephone(Telephone telephone)
        {
            await _telephoneService.Create(telephone);

            return CustomResponse(telephone);
        }

        // DELETE: api/Telephones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Telephone>> DeleteTelephone(int id)
        {
            var telephone = await _telephoneService.GetById(id);
            if (telephone == null)
            {
                return NotFound();
            }

            await _telephoneService.Delete(telephone.Id);

            return CustomResponse(telephone);
        }
    }
}
