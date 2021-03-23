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
    public class StatesController : MainController
    {
        private readonly IStateService _stateService;

        public StatesController(IStateService stateService,
                                INotificator notificator,
                                IHttpContextAccessor httpContextAccessor,
                                IApiUserService apiUserService) : base(notificator, httpContextAccessor, apiUserService)
        {
            _stateService = stateService;
        }

        // GET: api/States
        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
        {
            //return await _context.States.ToListAsync();
            return await _stateService.GetAll();
        }

        // GET: api/States/5
        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetState(int id)
        {
            var state = await _stateService.GetById(id);

            if (state == null)
            {
                return NotFound();
            }

            return state;
        }

        // PUT: api/States/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutState(int id, State state)
        {
            if (id != state.Id)
            {
                return BadRequest();
            }

            try
            {
                await _stateService.Update(state);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_stateService.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CustomResponse(state);
        }

        // POST: api/States
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<State>> PostState(State state)
        {
            await _stateService.Create(state);

            return CustomResponse(state);
        }

        // DELETE: api/States/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<State>> DeleteState(int id)
        {
            var state = await _stateService.GetById(id);
            if (state == null)
            {
                return NotFound();
            }

            await _stateService.Delete(state.Id);

            return CustomResponse(state);
        }
    }
}
