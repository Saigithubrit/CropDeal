
using CropDealWebAPI.Dtos.UserProfile;
using CropDealWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace CropDealWebAPI.Repository
{
    public class UserProfileRepository : IRepository<UserProfile, int>
    {
        CropDealContext _context;
        ExceptionRepositry _exception;

        public UserProfileRepository(CropDealContext context, ExceptionRepositry exception)
        {
            _context = context;
            _exception = exception;
        }



        #region CreateUser
        /// <summary>
        /// this method is used to create user
        /// </summary>
        /// <param name="context"></param>
        public Task<int> CreateAsync(UserProfile item)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region DeleteAsync
        /// <summary>
        /// this method is used to delete user
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(UserProfile userProfile)
        {
            try
            {
                _context.UserProfiles.Remove(userProfile);
                await _context.SaveChangesAsync();
                var response = StatusCodes.Status200OK;
                return response;
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At userProfileRepositry in  DeleteAsync";
                _exception.AddException(ex, causedAt);
            }
            finally
            {

            }
            return 404;
        }

        #endregion

        #region UserExists
        /// <summary>
        /// this method is used to see wheater user exsists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public bool Exists(int email)
        {
            try
            {
                return (_context.UserProfiles?.Any(e => e.UserId == email)).GetValueOrDefault();
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At userProfileRepositry in  Exists";
                _exception.AddException(ex, causedAt);

            }
            finally
            {

            }
            return false;
        }
        #endregion

        #region GetUsers
        /// <summary>
        /// this method is used to get all users
        /// </summary>
        /// <returns></returns>

        public async Task<IEnumerable<UserProfile>> GetAsync()
        {
            try
            {
                return await _context.UserProfiles.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {

                string causedAt = "Error casued At userProfileRepositry in  GetAsync";
                _exception.AddException(ex, causedAt);
            }
            finally
            {

            }
            return null;
        }
        #endregion

        #region GetUserbyId
        /// <summary>
        /// this method is used to get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<UserProfile> GetIdAsync(int id)
        {
            try
            {

                return await _context.UserProfiles
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.UserId == id);

            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At userProfileRepositry in  GetIdAsync";
                _exception.AddException(ex, causedAt);
                return null;
            }
            finally
            {

            }
        }
        #endregion

        #region UpdateAsync
        /// <summary>
        /// this method is used to update User
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public async Task<int> UpdateAsync(UserProfile item)
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                var response = StatusCodes.Status200OK;
                return response;
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At userProfileRepositry in  UpdateAsync";
                _exception.AddException(ex, causedAt);
                return 404;
            }
            finally { }

        }
        #endregion



    }
}
