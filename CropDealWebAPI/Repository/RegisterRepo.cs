using CropDealWebAPI.Dtos.UserProfile;
using CropDealWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace CropDealWebAPI.Repository
{
    public class RegisterRepo : IRegisterRepository<CreateUserDto, UserProfile>
    {
        CropDealContext _context;
        ExceptionRepositry _exception;
        public RegisterRepo(CropDealContext context, ExceptionRepositry exception)
        {
            _context = context;
            _exception = exception;
        }


        #region RegisterUser
        /// <summary>
        /// this method is used to register User
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ActionResult<UserProfile>> CreateAsync(CreateUserDto userProfileDto)
        {
            try
            {

                using var hmac = new HMACSHA512();
                var user = new UserProfile
                {
                    UserName = userProfileDto.UserName,
                    UserEmail = userProfileDto.UserEmail,
                    UserPhnumber = userProfileDto.UserPhnumber,
                    UserType = userProfileDto.UserType,
                    UserBankName = userProfileDto.UserBankName,
                    UserIfsc = userProfileDto.UserIfsc,
                    UserAccnumber = userProfileDto.UserAccnumber,
                    UserAddress = userProfileDto.UserAddress,

                    UserPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userProfileDto.UserPassword)),
                    UserPasswordSalt = hmac.Key
                };

                _context.UserProfiles.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At Register in  CreateAsync";
                _exception.AddException(ex, causedAt);


            }
            finally
            {

            }
            return null;

        }
        #endregion

        #region userExists
        /// <summary>
        /// this method is used check user exsists or not
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public bool UserExists(CreateUserDto item)
        {
            try
            {
                return (_context.UserProfiles?.Any(e => e.UserEmail == item.UserEmail)).GetValueOrDefault();
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At Register in  UserExists";
                _exception.AddException(ex, causedAt);
                return false;
            }
            finally
            {

            }
        }
        #endregion
    }
}
