using CropDealWebAPI.Models;
using CropDealWebAPI.Repository;
using CropDealWebAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CropDealWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _Service;
        private IToken _token;

        public LoginController(LoginService service, IToken token)
        {

            _Service = service;
            _token = token;
        }

        [HttpPost("login")]

        public async Task<ActionResult<Token>> Login(Login item)
        {
            

           var res = await _Service.Login(item);
            int res1 = await _Service.GetUserId(item.Email);


            if (res == 200)
            {
                string token = _token.CreateToken(item);

                Token tk = new Token();
                tk.token = token;
                tk.UserId = res1;
                return tk;


            }
            else if(res == 404)
            {
                return BadRequest("You are not registered");
            }
            else if(res== 401)
            {
                return Unauthorized("Password is wrong");
            }
            else
            {
                return BadRequest("Your account is blocked,please contact Admininstrator");

            }
        }

       

    }
}
