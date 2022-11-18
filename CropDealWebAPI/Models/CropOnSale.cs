using System;
using System.Collections.Generic;

namespace CropDealWebAPI.Models
{
    public partial class CropOnSale
    {
        public int CropAdId { get; set; }
        public string CropName { get; set; } = null!;
        public string CropType { get; set; } = null!;
        public int CropQty { get; set; }
        public decimal CropPrice { get; set; }
        public int FarmerId { get; set; }
        public int CropId { get; set; }

        public virtual Crop Crop { get; set; } = null!;
        public virtual UserProfile Farmer { get; set; } = null!;
    }
}
