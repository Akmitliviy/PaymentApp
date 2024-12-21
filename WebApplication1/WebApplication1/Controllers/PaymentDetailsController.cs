using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private readonly PaymentDbContext _context;

        public PaymentDetailsController(PaymentDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetailsViewModel>>> GetPaymentDetails()
        {
            return await _context.PaymentDetails.ToListAsync();
        }

        // GET: api/PaymentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetailsViewModel>> GetPaymentDetailsViewModel(Guid id)
        {
            var paymentDetailsViewModel = await _context.PaymentDetails.FindAsync(id);

            if (paymentDetailsViewModel == null)
            {
                return NotFound();
            }

            return paymentDetailsViewModel;
        }

        // PUT: api/PaymentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetailsViewModel(Guid id, PaymentDetailsViewModel paymentDetailsViewModel)
        {
            if (id != paymentDetailsViewModel.PaymentDetailsId)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetailsViewModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailsViewModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPaymentDetailsViewModel", new { id = paymentDetailsViewModel.PaymentDetailsId }, paymentDetailsViewModel);
        }

        // POST: api/PaymentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentDetailsViewModel>> PostPaymentDetailsViewModel(PaymentDetailsViewModel paymentDetailsViewModel)
        {
            _context.PaymentDetails.Add(paymentDetailsViewModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDetailsViewModel", new { id = paymentDetailsViewModel.PaymentDetailsId }, paymentDetailsViewModel);
        }

        // DELETE: api/PaymentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetailsViewModel(Guid id)
        {
            var paymentDetailsViewModel = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetailsViewModel == null)
            {
                return NotFound();
            }

            _context.PaymentDetails.Remove(paymentDetailsViewModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentDetailsViewModelExists(Guid id)
        {
            return _context.PaymentDetails.Any(e => e.PaymentDetailsId == id);
        }
    }
}
