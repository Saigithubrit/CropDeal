using System;
using System.Collections.Generic;

namespace CropDealWebAPI.Models
{
    public partial class Crop
    {
        public Crop()
        {
            CropOnSales = new HashSet<CropOnSale>();
        }

        public int CropId { get; set; }
        public string CropName { get; set; } = null!;
        public string CropImage { get; set; } = null!;

        public virtual ICollection<CropOnSale> CropOnSales { get; set; }
    }
}
