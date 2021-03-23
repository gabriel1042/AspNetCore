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
    public class EmailsController : MainController
    {
        private readonly IEmailService _emailService;

        public EmailsController(IEmailService emailService,
                                INotificator notificator,
                                IHttpContextAccessor httpContextAccessor,
                                IApiUserService apiUserService) : base(notificator, httpContextAccessor, apiUserService)
        {
            _emailService = emailService;
        }

        // GET: api/Emails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Email>>> GetEmails()
        {
            //return await _context.Emails.ToListAsync();
            return await _emailService.GetAll();
        }

        // GET: api/Emails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Email>> GetEmail(int id)
        {
            var email = await _emailService.GetById(id);

            if (email == null)
            {
                return NotFound();
            }

            return email;
        }

        // PUT: api/Emails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmail(int id, Email email)
        {
            if (id != email.Id)
            {
                return BadRequest();
            }

            try
            {
                await _emailService.Update(email);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_emailService.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CustomResponse(email);
        }

        // POST: api/Emails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Email>> PostEmail(Email email)
        {
            await _emailService.Create(email);

            return CustomResponse(email);
        }

        // DELETE: api/Emails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Email>> DeleteEmail(int id)
        {
            var email = await _emailService.GetById(id);
            if (email == null)
            {
                return NotFound();
            }

            await _emailService.Delete(email.Id);

            return CustomResponse(email);
        }
    }
}
