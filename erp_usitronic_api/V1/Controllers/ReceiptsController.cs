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
    public class ReceiptsController : MainController
    {
        private readonly IReceiptService _receiptService;

        public ReceiptsController(IReceiptService receiptService,
                                INotificator notificator,
                                IHttpContextAccessor httpContextAccessor,
                                IApiUserService apiUserService) : base(notificator, httpContextAccessor, apiUserService)
        {
            _receiptService = receiptService;
        }

        // GET: api/Receipts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receipt>>> GetReceipts()
        {
            //return await _context.Receipts.ToListAsync();
            return await _receiptService.GetAll();
        }

        // GET: api/Receipts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receipt>> GetReceipt(int id)
        {
            var receipt = await _receiptService.GetById(id);

            if (receipt == null)
            {
                return NotFound();
            }

            return receipt;
        }

        // PUT: api/Receipts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceipt(int id, Receipt receipt)
        {
            if (id != receipt.Id)
            {
                return BadRequest();
            }

            try
            {
                await _receiptService.Update(receipt);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_receiptService.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CustomResponse(receipt);
        }

        [HttpPut("changepaidstatus/{id}")]
        public async Task<IActionResult> PutReceiptChangePaidStatus(int id, ReceiptPaid receiptPaid)
        {
            var receipt = new Receipt { Id = receiptPaid.Id, Paid = receiptPaid.Paid };
            if (id != receipt.Id)
            {
                return BadRequest();
            }

            try
            {
                if (!await _receiptService.UpdatePaidStatus(receipt))
                    CustomResponse();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_receiptService.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CustomResponse(receiptPaid);
        }

        // POST: api/Receipts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Receipt>> PostReceipt(Receipt receipt)
        {
            await _receiptService.Create(receipt);

            return CustomResponse(receipt);
        }

        // DELETE: api/Receipts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Receipt>> DeleteReceipt(int id)
        {
            var receipt = await _receiptService.GetById(id);
            if (receipt == null)
            {
                return NotFound();
            }

            await _receiptService.Delete(receipt.Id);

            return CustomResponse(receipt);
        }
    }
}
