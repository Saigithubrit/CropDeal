namespace CropDealWebAPI.Dtos.CropOnSale
{
    public class GetCropOnSaleDto:BaseCropOnSaleDto
    {
        public string CropName { get; set; }
        public string CropType { get; set; } 
        public int CropQty { get; set; }
        public decimal CropPrice { get; set; }
        public int FarmerId { get; set; }
        public int CropId { get; set; }

    }
}
