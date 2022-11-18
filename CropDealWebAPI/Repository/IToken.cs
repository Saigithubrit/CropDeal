using CropDealWebAPI.Models;

namespace CropDealWebAPI.Repository
{
    public interface IToken
    {
        public string CreateToken(Login login);
    }
}
