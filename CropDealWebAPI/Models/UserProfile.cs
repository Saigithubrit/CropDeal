using System;
using System.Collections.Generic;

namespace CropDealWebAPI.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            CropOnSales = new HashSet<CropOnSale>();
            InvoiceDealerAccNumberNavigations = new HashSet<Invoice>();
            InvoiceFarmerAccNumberNavigations = new HashSet<Invoice>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserAddress { get; set; } = null!;
        public string UserPhnumber { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public byte[]? UserPasswordHash { get; set; }
        public byte[] UserPasswordSalt { get; set; } = null!;
        public int UserAccnumber { get; set; }
        public string UserIfsc { get; set; } = null!;
        public string UserBankName { get; set; } = null!;
        public string UserType { get; set; } = null!;
        public string? UserStatus { get; set; }

        public virtual ICollection<CropOnSale> CropOnSales { get; set; }
        public virtual ICollection<Invoice> InvoiceDealerAccNumberNavigations { get; set; }
        public virtual ICollection<Invoice> InvoiceFarmerAccNumberNavigations { get; set; }
    }
}
