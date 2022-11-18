using CropDealWebAPI.Models;

namespace CropDealWebAPI.Repository
{
    public interface IPaymentRepository
    {
        public  Task<string> AddPayment(Payment payment);
        List<Invoice> ViewInvoiceAsync(int UserId);

        List<Invoice> ViewDealerInvoiceAsync(int UserId);
    }
}
