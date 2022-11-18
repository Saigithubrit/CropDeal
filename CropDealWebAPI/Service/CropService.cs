using CropDealWebAPI.Models;
using CropDealWebAPI.Repository;

namespace CropDealWebAPI.Service
{
    public class CropService
    {
        IRepository<Crop, int> _repository;
        public CropService(IRepository<Crop, int> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Crop>> GetCrop()
        {
            return await _repository.GetAsync();
        }

        public async Task<Crop> GetCropById(int id)
        {
            return await _repository.GetIdAsync(id);
        }
        public async Task<int> CreateCrop(Crop item)
        {
            return await _repository.CreateAsync(item);
        }
        public Task<int> UpdateCrop(Crop item)
        {
            return _repository.UpdateAsync(item);
        }
        public bool CropExists(int id)
        {
            return _repository.Exists(id);
        }
        public Task<int> DeleteCrop(Crop item)
        {
            return _repository.DeleteAsync(item);
        }
    }
}

