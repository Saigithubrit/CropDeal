using CropDealWebAPI.Dtos.UserProfile;
using CropDealWebAPI.Models;
using CropDealWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CropDealWebAPI.Service
{
    public class RegisterService
    {
        IRegisterRepository<CreateUserDto, UserProfile> _repository;
        public RegisterService(IRegisterRepository<CreateUserDto, UserProfile> repository)
        {
            _repository = repository; 
        }
        public async Task<ActionResult<UserProfile>> RegisterUser(CreateUserDto createUserDto)
        {
            return await _repository.CreateAsync(createUserDto);
        }
        public bool UserExisits(CreateUserDto email)
        {
            return _repository.UserExists(email);
        }
    }
}
