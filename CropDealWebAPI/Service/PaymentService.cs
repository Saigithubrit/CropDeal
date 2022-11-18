using CropDealWebAPI.Models;
using CropDealWebAPI.Repository;

namespace CropDealWebAPI.Service
{
    public class PaymentService
    {
        private IPaymentRepository _repository;
        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> AddPayment(Payment payment)
        {
            return await _repository.AddPayment(payment);
        }

        public List<Invoice> ViewInvoiceAsync(int UserId)
        {
            return _repository.ViewInvoiceAsync(UserId);
        }
        public List<Invoice> ViewDealerInvoiceAsync(int UserId)
        {
            return _repository.ViewDealerInvoiceAsync(UserId);
        }

    }
}
