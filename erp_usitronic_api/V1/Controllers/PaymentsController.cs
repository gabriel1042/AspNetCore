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
    public class PaymentsController : MainController
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService,
                                INotificator notificator,
                                IHttpContextAccessor httpContextAccessor,
                                IApiUserService apiUserService) : base(notificator, httpContextAccessor, apiUserService)
        {
            _paymentService = paymentService;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            //return await _context.Payments.ToListAsync();
            return await _paymentService.GetAll();
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _paymentService.GetById(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }

            try
            {
                await _paymentService.Update(payment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_paymentService.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CustomResponse(payment);
        }

        [HttpPut("changepaidstatus/{id}")]
        public async Task<IActionResult> PutPaymentChangePaidStatus(int id, PaymentPaid paymentPaid)
        {
            var payment = new Payment { Id = paymentPaid.Id, Paid = paymentPaid.Paid };
            if (id != payment.Id)
            {
                return BadRequest();
            }

            try
            {
                await _paymentService.UpdatePaidStatus(payment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_paymentService.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CustomResponse(paymentPaid);
        }

        // POST: api/Payments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            await _paymentService.Create(payment);

            return CustomResponse(payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Payment>> DeletePayment(int id)
        {
            var payment = await _paymentService.GetById(id);
            if (payment == null)
            {
                return NotFound();
            }

            await _paymentService.Delete(payment.Id);

            return CustomResponse(payment);
        }
    }
}
