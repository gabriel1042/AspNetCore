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
    public class SuppliersController : MainController
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService,
                                INotificator notificator,
                                IHttpContextAccessor httpContextAccessor,
                                IApiUserService apiUserService) : base(notificator, httpContextAccessor, apiUserService)
        {
            _supplierService = supplierService;
        }

        // GET: api/Suppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            //return await _context.Suppliers.ToListAsync();
            return await _supplierService.GetAll();
        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            var supplier = await _supplierService.GetById(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return supplier;
        }

        // PUT: api/Suppliers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return BadRequest();
            }

            try
            {
                await _supplierService.Update(supplier);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_supplierService.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CustomResponse(supplier);
        }

        // POST: api/Suppliers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier(Supplier supplier)
        {
            await _supplierService.Create(supplier);

            return CustomResponse(supplier);
        }

        // DELETE: api/Suppliers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Supplier>> DeleteSupplier(int id)
        {
            var supplier = await _supplierService.GetById(id);
            if (supplier == null)
            {
                return NotFound();
            }

            await _supplierService.Delete(supplier.Id);

            return CustomResponse(supplier);
        }
    }
}
