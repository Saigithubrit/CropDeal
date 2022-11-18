using CropDealWebAPI.Dtos.UserProfile;
using CropDealWebAPI.Models;
using CropDealWebAPI.Repository;

namespace CropDealWebAPI.Service
{
    public class UserProfileService
    {
        IRepository<UserProfile, int> _repository;
        public UserProfileService(IRepository<UserProfile, int> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<UserProfile>> GetUser()
        {
            return await _repository.GetAsync();
        }

        public async Task<UserProfile> GetUserById(int id)
        {
            return await _repository.GetIdAsync(id);
        }
        
        public async Task<int> UpdateUser(UserProfile userProfile)
        {
            return await _repository.UpdateAsync(userProfile);
        }
        public bool UserExists(int id)
        {
            return _repository.Exists(id);
        }
        public Task<int> DeleteUser(UserProfile userProfile)
        {
            return _repository.DeleteAsync(userProfile);
        }
    }


}

