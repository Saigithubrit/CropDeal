using System.ComponentModel.DataAnnotations;

namespace CropDealWebAPI.Dtos.Crop
{
    public class CreateCropDto
    {
        [Required]
        public string CropName { get; set; } 
        [Required]
        public string CropImage { get; set; } = null!;
    }
}
