using CropDealWebAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CropDealWebAPI.Repository
{
    public class TokenRepo : IToken
    {
        CropDealContext _context;
        private readonly IConfiguration _configuration;
        ExceptionRepositry _exception;

        public TokenRepo(CropDealContext context, IConfiguration config,ExceptionRepositry exception)
        {
            _context = context;
           _configuration=config;
            _exception = exception; 
        }


        #region Token Creation
        /// <summary>
        /// this method is used to create token
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string CreateToken(Login login)
        {
            try
            {
                List<Claim> claims = new List<Claim>
                {
                 new Claim(ClaimTypes.Email, login.Email),
                new Claim(ClaimTypes.Role, login.Role)
                 };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;


            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At TokenRepo in  CreateToken";
                _exception.AddException(ex, causedAt);
                return null;
            }
            finally
            {

            }
        }
        #endregion
    }
}
