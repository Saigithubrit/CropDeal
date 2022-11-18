using CropDealWebAPI.Models;
using CropDealWebAPI.Repository;

namespace CropDealWebAPI.Service
{
    public class ViewCropService
    {
        private IViewCropRepository _repository;
        public ViewCropService(IViewCropRepository repository)
        {
            _repository = repository;
        }
        public List<ViewCrop> ViewCrops()
        {
            return _repository.ViewCropsAsync();
        }

        public List<ViewCrop> ViewFarmerCrops(UserId id)
        {
            return _repository.ViewFarmerCropsAsync(id);
        }
    }
}
