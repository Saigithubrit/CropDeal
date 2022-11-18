using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CropDealWebAPI.Models;
using CropDealWebAPI.Repository;

namespace CropDealWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly CropDealContext _context;
        ExceptionRepositry _exception;

        public InvoicesController(CropDealContext context, ExceptionRepositry exception)
        {
            _context = context;
            _exception = exception;


        }

        #region Get Invoices
        /// <summary>
        /// this method is used to Get Invoices
        /// </summary>

        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
            try
            {
                if (_context.Invoices == null)
                {
                    return NotFound();
                }
                return await _context.Invoices.ToListAsync();
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At Invoices in  GetInvoices";
                _exception.AddException(ex, causedAt);
                return null;

            }
            finally { }
        }
        #endregion

        #region Get Invoice By ID
        /// <summary>
        /// this method is used to get invoice by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            try
            {
                if (_context.Invoices == null)
                {
                    return NotFound();
                }
                var invoice = await _context.Invoices.FindAsync(id);

                if (invoice == null)
                {
                    return NotFound();
                }

                return invoice;
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At Invoices in  GetInvoicesbyid";
                _exception.AddException(ex, causedAt);

                return null;
            }
            finally
            {

            }

        }
        #endregion

        #region UpdateInvoice
        /// <summary>
        /// this method is used to update invoice
        /// </summary>
        /// <param name="id, invoice"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        // PUT: api/Invoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, Invoice invoice)
        {
            if (id != invoice.InvoiceId)
            {
                return BadRequest();
            }


            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At Invoices in  PutInvoice";
                _exception.AddException(ex, causedAt);
                return null;
            }
            finally { }

            return NoContent();
        }
        #endregion

        #region PostInvoice
        /// <summary>
        /// this method is used to create invoice
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        // POST: api/Invoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            try
            {
                if (_context.Invoices == null)
                {
                    return Problem("Entity set 'CropDealContext.Invoices'  is null.");
                }
                _context.Invoices.Add(invoice);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetInvoice", new { id = invoice.InvoiceId }, invoice);
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At Invoices in  PutInvoice";
                _exception.AddException(ex, causedAt);

                return null;
            }
            finally { }
        }
        #endregion

        #region DeleteInvoice
        /// <summary>
        /// this method is used to delete invoice
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            try
            {
                if (_context.Invoices == null)
                {
                    return NotFound();
                }
                var invoice = await _context.Invoices.FindAsync(id);
                if (invoice == null)
                {
                    return NotFound();
                }

                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At Invoices in  DeleteInvoices";
                _exception.AddException(ex, causedAt);
                return null;
            }
            finally { }

            return NoContent();
        }
        #endregion

        #region InvoiceExists
        /// <summary>
        /// this method is used to check the existence of invoice
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool InvoiceExists(int id)
        {
            try
            {
                return (_context.Invoices?.Any(e => e.InvoiceId == id)).GetValueOrDefault();
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At Invoices in InvoicesExists";
                _exception.AddException(ex, causedAt);
                return false;
            }
            finally { }
        }
        #endregion
    }
}
