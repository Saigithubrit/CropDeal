using System.ComponentModel.DataAnnotations;

namespace CropDealWebAPI.Dtos.CropOnSale
{
    public class CreateCropOnSaleDto
    {
        [Required]
        public string CropName { get; set; }
        [Required]
        public string CropType { get; set; }
        [Required]
        public int CropQty { get; set; }
        [Required]
        public decimal CropPrice { get; set; }
        [Required]
        public int FarmerId { get; set; }
        [Required]
        public int CropId { get; set; }
    }
}
