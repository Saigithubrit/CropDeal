using CropDealWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CropDealWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CropDealContext _context;
        public UserController(CropDealContext context)
        {
            _context = context;

        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult ChangeUserStatus(ChangeUser user)
        {
            try
            {
                (from p in _context.UserProfiles
                 where p.UserId == user.userId
                 select p).ToList()
                        .ForEach(x => x.UserStatus = user.userStaus);

                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
    }
}
