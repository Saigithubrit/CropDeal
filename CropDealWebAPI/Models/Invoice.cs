using System;
using System.Collections.Generic;

namespace CropDealWebAPI.Models
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public int DealerAccNumber { get; set; }
        public int FarmerAccNumber { get; set; }
        public string CropName { get; set; } = null!;
        public string CropType { get; set; } = null!;
        public int CropQty { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal OrderTotal { get; set; }

        public virtual UserProfile DealerAccNumberNavigation { get; set; } = null!;
        public virtual UserProfile FarmerAccNumberNavigation { get; set; } = null!;
    }
}
