using CropDealWebAPI.Models;
using CropDealWebAPI.Repository;

namespace CropDealWebAPI.Service
{
    public class CropOnSaleService
    {
        IRepository<CropOnSale, int> _repository;
        public CropOnSaleService(IRepository<CropOnSale, int> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<CropOnSale>> GetCropOnSale()
        {
            return await _repository.GetAsync();
        }

        public async Task<CropOnSale> GetCropOnSaleById(int id)
        {
            return await _repository.GetIdAsync(id);
        }

        public async Task<int> CreateCropOnSale(CropOnSale item)
        {
            return await _repository.CreateAsync(item);
        }
        public Task<int> UpdateCrop(CropOnSale item)
        {
            return _repository.UpdateAsync(item);
        }
        public bool CropOnSaleExists(int id)
        {
            return _repository.Exists(id);
        }
        public Task<int> DeleteCropOnSale(CropOnSale item)
        {
            return _repository.DeleteAsync(item);
        }
    }
}
