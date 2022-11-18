using CropDealWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace CropDealWebAPI.Repository
{
    public class LoginRepo : ILoginRepository<Login, int>
    {
        CropDealContext _context;
        ExceptionRepositry _exception;
        public LoginRepo(CropDealContext context, ExceptionRepositry exception)
        {
            _context = context;
            _exception = exception;
        }

        #region getuserId
        /// <summary>
        /// this method gets user id of the user
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> GetUserId(string item)
        {
            try
            {
                var user = await _context.UserProfiles
                         .SingleOrDefaultAsync(x => x.UserEmail == item);

                if (user != null)
                {
                    int userid = user.UserId;
                    return userid;

                }
                else
                {
                    return 404;
                }
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At LoginRepo in  GetUserId";
                _exception.AddException(ex, causedAt);
                return 404;
            }
            finally
            {

            }
        }
        #endregion

        #region Login
        /// <summary>
        /// this method is used to Login
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> Login(Login item)
        {
            try
            {
                if (item.Role == "Admin")
                {
                    var user = await _context.Admins
                        .SingleOrDefaultAsync(x => x.AdminEmail == item.Email);
                    if (user == null)
                    {
                        return 404;
                    }
                    else if (user.AdminPassword != item.Password)
                    {
                        return 401;
                    }
                    else
                    {
                        return 200;
                    }


                }
                else
                {
                    var user = await _context.UserProfiles
                        .SingleOrDefaultAsync(x => x.UserEmail == item.Email);

                    if (user == null)
                    {
                        return 404;
                    }
                    else
                    {


                        if (user.UserType == item.Role && user.UserStatus == "ACTIVE")
                        {

                            using var hmac = new HMACSHA512(user.UserPasswordSalt);

                            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(item.Password));

                            for (int i = 0; i < hash.Length; i++)
                            {
                                if (hash[i] != user.UserPasswordHash[i])
                                {
                                    return 401;
                                }

                            }
                        }
                        else
                        {
                            return 400;
                        }
                    }
                    return 200;
                }

            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At LoginRepo in  Login";
                _exception.AddException(ex, causedAt);
                return 404;

            }


            finally
            {

            }
        }
        #endregion
    }
}
