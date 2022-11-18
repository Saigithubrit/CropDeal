using Microsoft.AspNetCore.Mvc;

namespace CropDealWebAPI.Repository
{
    public interface ILoginRepository<TEntity, TKey> where TEntity : class
    {
        Task<int> Login(TEntity item);
        Task<int> GetUserId(string item);


    }
}
