using CropDealWebAPI.Models;
using CropDealWebAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CropDealWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _Service;

        public PaymentController(PaymentService service)
        {

            _Service = service;
        }

        [Authorize(Roles = "Dealer")]

        [HttpPost]
        public async Task<IActionResult> AddPayment(Payment payment)
        {
            return Ok( await _Service.AddPayment(payment));

        }
        [Authorize]
        [HttpGet("FarmerInvoice")]
        public List<Invoice> GetInvoice(int UserId)
        {
            return _Service.ViewInvoiceAsync(UserId);

        }
        [Authorize]
        [HttpGet("DealerInvoice")]
        public List<Invoice> GetDealerInvoice(int UserId)
        {
            return _Service.ViewDealerInvoiceAsync(UserId);

        }

    }
}
