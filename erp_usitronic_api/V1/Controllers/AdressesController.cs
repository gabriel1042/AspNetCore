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
    public class AdressesController : MainController
    {
        private readonly IAddressService _addressService;

        public AdressesController(IAddressService addressService,
                                INotificator notificator,
                                IHttpContextAccessor httpContextAccessor,
                                IApiUserService apiUserService) : base(notificator, httpContextAccessor, apiUserService)
        {
            _addressService = addressService;
        }

        // GET: api/Address
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            //return await _context.Address.ToListAsync();
            return await _addressService.GetAll();
        }

        // GET: api/Address/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            var address = await _addressService.GetById(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Address/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            if (id != address.Id)
            {
                return BadRequest();
            }

            try
            {
                await _addressService.Update(address);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_addressService.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CustomResponse(address);
        }

        // POST: api/Address
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            await _addressService.Create(address);

            return CustomResponse(address);
        }

        // DELETE: api/Address/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            var address = await _addressService.GetById(id);
            if (address == null)
            {
                return NotFound();
            }

            await _addressService.Delete(address.Id);

            return CustomResponse(address);
        }
    }
}
