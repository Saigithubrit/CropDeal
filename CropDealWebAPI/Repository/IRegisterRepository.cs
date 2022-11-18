using CropDealWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CropDealWebAPI.Repository
{
    public interface IRegisterRepository<TEntity, TKey> where TEntity : class
    {
        Task<ActionResult<UserProfile>> CreateAsync(TEntity item);

        bool UserExists(TEntity item);
    }
}
