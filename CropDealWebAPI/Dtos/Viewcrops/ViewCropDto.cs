namespace CropDealWebAPI.Dtos.Viewcrops
{
    public class ViewCropDto
    {
        public int CropAdId { get; set; }
        public string CropImage { get; set; }
        public string CropName { get; set; }
        public string CropType { get; set; }
        public int CropQty { get; set; }
        public decimal CropPrice { get; set; }
    }
}
