using CropDealWebAPI.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace CropDealWebAPI.Repository
{
    public class PaymentRepo : IPaymentRepository
    {
        CropDealContext _context;
        ExceptionRepositry _exception;
        public PaymentRepo(CropDealContext context, ExceptionRepositry exception)
        {
            _context = context;
            _exception = exception; 
        }

        #region Payment
        /// <summary>
        /// this method is exwcuted after payment to gerate invoice and to add invoice
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public async Task<string> AddPayment(Payment payment)
        {
            try
            {
                var Crpid = payment.CropAdid;
                UserProfile farmer;
                UserProfile dealer;

                var query =
                    from f in _context.CropOnSales
                    where Crpid == f.CropAdId
                    join g in _context.UserProfiles
                         on payment.FarmerId equals g.UserId
                    join d in _context.UserProfiles
                         on payment.UserId equals d.UserId
                    select new Invoice()
                    {
                        CropName = f.CropName,
                        CropQty = f.CropQty,
                        CropType = f.CropType,
                        OrderTotal = f.CropPrice,
                        InvoiceDate = DateTime.Now,
                        FarmerAccNumber = g.UserAccnumber,
                        DealerAccNumber = d.UserAccnumber

                    };
                List<Invoice> invoices = query.ToList();

                Invoice invoice1 = new Invoice();
                foreach (var invoice in invoices)
                {
                    invoice1.CropName = invoice.CropName;
                    invoice1.CropQty = invoice.CropQty;
                    invoice1.CropType = invoice.CropType;
                    invoice1.OrderTotal = invoice.OrderTotal;
                    invoice1.InvoiceDate = invoice.InvoiceDate;
                    invoice1.FarmerAccNumber = invoice.FarmerAccNumber;
                    invoice1.DealerAccNumber = invoice.DealerAccNumber;

                }
                var user = await _context.UserProfiles
                       .FirstOrDefaultAsync(x => x.UserId == payment.FarmerId);

                var result = await _context.UserProfiles
                       .FirstOrDefaultAsync(x => x.UserId == payment.UserId);

                if (user != null)
                {
                    farmer = user;
                    dealer = result;
                }
                else
                {
                    return "400";
                }

                if (await AddInvoice(invoice1, Crpid, farmer, dealer))
                {

                    return "200";
                }
                else
                {
                    return "400";
                }
            }
            catch (Exception ex)
            {
                string filePath = @"E:\Error.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Error Caused at AddPayment in Payment");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }


                }
                return null;
            }
            finally
            {

            }

        }
        #endregion

        #region Add invoice
        /// <summary>
        /// this method is for adding invoice
        /// </summary>
        /// <param name="invoice"></param>
        /// <param name="crpid"></param>
        /// <param name="farmer"></param>
        /// <param name="dealer"></param>
        /// <returns></returns>
        public async Task<bool> AddInvoice(Invoice invoice, int crpid, UserProfile farmer, UserProfile dealer)
        {
            try
            {
                _context.Invoices.Add(invoice);
                await _context.SaveChangesAsync();

                await DeleteCrop(crpid);
                await SendEmail(invoice, farmer, dealer);
                await SendEmailToDealer(invoice, farmer, dealer);


                var response = true;
                return response;
            }
            catch (Exception ex)
            {
                string filePath = @"E:\Error.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Error Caused at AddInvoice in Payment");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }

                }
                return false;
            }
            finally
            {

            }
        }
        #endregion

        #region Delete crop
        public async Task<bool> DeleteCrop(int crpid)
        {
            try
            {
                var crop = await _context.CropOnSales
                            .FirstOrDefaultAsync(x => x.CropAdId == crpid);

                _context.CropOnSales.Remove(crop);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At Payment in DeleteCrop";
                _exception.AddException(ex,causedAt);   

            }

            finally
            {

            }
            return false;


        }
        #endregion

        #region send Email to farmer
        /// <summary>
        /// This method is used for sending email to farmers
        /// </summary>
        /// <param name="invoice"></param>
        /// <param name="farmer"></param>
        /// <param name="Dealer"></param>
        /// <returns></returns>
        public async Task<bool> SendEmail(Invoice invoice, UserProfile farmer, UserProfile Dealer)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("cropdeal.info@gmail.com"));
                email.To.Add(MailboxAddress.Parse(farmer.UserEmail));
                email.Subject = "Your crops are sold";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = "Dear " + farmer.UserName + ",<br>" +
                    "Congratulations ! your crop has been sold successfully, Login Now to Download your Invoice <br>" +
                    "<strong>CROP DETAILS &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DEALER DETAILS             </strong><br>" +
                    "CROP NAME :" + invoice.CropName + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DEALER NAME : " + Dealer.UserName + "<br> " +
                    "CROP TYPE :" + invoice.CropType + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DEALER CONTACT :" + Dealer.UserPhnumber + "<br>" +
                    "CROP QUANTITY :" + invoice.CropQty + "Kgs &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DEALER ADDRESS :" + Dealer.UserAddress + "<br>" +
                    " ----------------------------------------------------------------------------------------------------------<br>" +
                    "ORDER TOTAL : Rs." + invoice.OrderTotal + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ORDER DATE      :" + invoice.InvoiceDate + "<br>" +
                     " ----------------------------------------------------------------------------------------------------------<br>" +
                    "Trasnfered from dealer Account number " + Dealer.UserAccnumber + " to your Account Number " + farmer.UserAccnumber + "<br>" +
                    "<br>                                                                                                         " +
                    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Enjoy selling your crop with us!      <br> " +
                    "<pre>                                                                                  regards,</pre>" +
                    "<pre>                                                                                      Crop Deal.</pre>"
                };
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("cropdeal.info@gmail.com", "smfjnuihuecstwgf");
                smtp.Send(email);
                smtp.Disconnect(true);
                return true;
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At Payment in  SendEmail";
                _exception.AddException(ex, causedAt);
            }
            finally
            {

            }
            return false;
        }
        #endregion

        #region send email to dealer
        /// <summary>
        /// this method is used to send email to dealer
        /// </summary>
        /// <param name="invoice"></param>
        /// <param name="farmer"></param>
        /// <param name="Dealer"></param>
        /// <returns></returns>


        public async Task<bool> SendEmailToDealer(Invoice invoice, UserProfile farmer, UserProfile Dealer)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("cropdeal.info@gmail.com"));
                email.To.Add(MailboxAddress.Parse(Dealer.UserEmail));
                email.Subject = "Your Order processed sucessfully !";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = "Dear " + Dealer.UserName + ",<br>" +
                    "Congratulations ! your order has been processed successfully , Login Now to Download your Invoice <br>" +
                    "<strong>CROP DETAILS &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FARMER DETAILS             </strong><br>" +
                    "CROP NAME :" + invoice.CropName + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FARMER NAME : " + farmer.UserName + "<br> " +
                    "CROP TYPE :" + invoice.CropType + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FARMER CONTACT :" + farmer.UserPhnumber + "<br>" +
                    "CROP QUANTITY :" + invoice.CropQty + "Kgs &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FARMER ADDRESS :" + farmer.UserAddress + "<br>" +
                    " ----------------------------------------------------------------------------------------------------------<br>" +
                    "ORDER TOTAL : Rs." + invoice.OrderTotal + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ORDER DATE      :" + invoice.InvoiceDate + "<br>" +
                     " ----------------------------------------------------------------------------------------------------------<br>" +
                    "Trasnfered from your Account number " + Dealer.UserAccnumber + " to farmer Account Number " + farmer.UserAccnumber + "<br>" +
                    "<br>                                                                                                         " +
                    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Enjoy Buying your crop with us!      <br> " +
                    "<pre>                                                                                  regards,</pre>" +
                    "<pre>                                                                                      Crop Deal.</pre>"
                };
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("cropdeal.info@gmail.com", "smfjnuihuecstwgf");
                smtp.Send(email);
                smtp.Disconnect(true);
                return true;
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At Payment in  SendEmailToDealer";
                _exception.AddException(ex, causedAt);
            }
            finally
            {

            }
            return false;
        }

        #endregion

        #region FarmersInvoice
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<Invoice> ViewInvoiceAsync(int UserId)
        {
            try
            {
                var query = from a in _context.UserProfiles
                            where a.UserId == UserId
                            select new Invoice()
                            {
                                FarmerAccNumber = a.UserAccnumber
                            };

                List<Invoice> invoice = query.ToList();
                int Accno;
                foreach (var i in invoice)
                {
                    Accno = i.FarmerAccNumber;



                    var res = from b in _context.Invoices
                              where Accno == b.FarmerAccNumber
                              select new Invoice()
                              {
                                  InvoiceId = b.InvoiceId,
                                  CropName = b.CropName,
                                  CropQty = b.CropQty,
                                  CropType = b.CropType,
                                  OrderTotal = b.OrderTotal,
                                  InvoiceDate = b.InvoiceDate,
                                  FarmerAccNumber = b.FarmerAccNumber,
                                  DealerAccNumber = b.DealerAccNumber



                              };


                    List<Invoice> invoices = res.ToList();
                    return invoices;
                }
              
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At Payment in  ViewInvoiceAsync";
                _exception.AddException(ex, causedAt);
            }
            finally
            {

            }

            return null;

        }
        #endregion

        #region DealerInvoice
        /// <summary>
        /// this method is used get dealer invoice
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<Invoice> ViewDealerInvoiceAsync(int UserId)
        {
            try
            {
                var query = from a in _context.UserProfiles
                            where a.UserId == UserId
                            select new Invoice()
                            {
                                DealerAccNumber = a.UserAccnumber
                            };

                List<Invoice> invoice = query.ToList();
                int Accno;
                foreach (var i in invoice)
                {
                    Accno = i.DealerAccNumber;



                    var res = from b in _context.Invoices
                              where Accno == b.DealerAccNumber
                              select new Invoice()
                              {
                                  InvoiceId = b.InvoiceId,
                                  CropName = b.CropName,
                                  CropQty = b.CropQty,
                                  CropType = b.CropType,
                                  OrderTotal = b.OrderTotal,
                                  InvoiceDate = b.InvoiceDate,
                                  DealerAccNumber = b.DealerAccNumber,
                                  FarmerAccNumber = b.FarmerAccNumber


                              };


                    List<Invoice> invoices = res.ToList();
                    return invoices;
                }
               
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At Payment in  ViewDealerInvoiceAsync";
                _exception.AddException(ex, causedAt);
            }
            finally { }
            return null;

        }
        #endregion
    }
}
