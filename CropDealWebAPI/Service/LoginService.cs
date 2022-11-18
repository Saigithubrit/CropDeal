using CropDealWebAPI.Models;
using CropDealWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CropDealWebAPI.Service
{
    public class LoginService
    {
        ILoginRepository<Login, int> _repository;
        public LoginService(ILoginRepository<Login, int> repository)
        {
            _repository = repository;
        }

        public async Task<int> Login(Login login)
        {
            return await _repository.Login(login);
        }
        public async Task<int> GetUserId(string userid)
        {
            return await _repository.GetUserId(userid);
        }
    }
}
