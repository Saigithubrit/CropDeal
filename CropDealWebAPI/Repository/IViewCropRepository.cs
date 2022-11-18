using CropDealWebAPI.Models;

namespace CropDealWebAPI.Repository
{
    public interface IViewCropRepository
    {
         List<ViewCrop> ViewCropsAsync();
        List<ViewCrop> ViewFarmerCropsAsync(UserId id);
    }
}
