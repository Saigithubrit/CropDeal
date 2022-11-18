using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CropDealWebAPI.Models;
using CropDealWebAPI.Dtos.UserProfile;
using AutoMapper;
using CropDealWebAPI.Repository;
using CropDealWebAPI.Service;
using Microsoft.AspNetCore.Authorization;

namespace CropDealWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : ControllerBase

    {

        private readonly IMapper mapper;
        private readonly UserProfileService _Service;
        private readonly RegisterService _RegisterService;

        public UserProfilesController(IMapper mapper, UserProfileService service, RegisterService registerService)
        {

            this.mapper = mapper;
            _Service = service;
            _RegisterService = registerService;
        }
        #region GetUserProfile
        /// <summary>
        /// this action is used to get all the users
        /// </summary>
        /// <returns></returns>
        // GET: api/UserProfiles
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetUserProfiles()
        {
            try
            {

                var users = await _Service.GetUser();
                var usersDto = mapper.Map<IEnumerable<GetUserDto>>(users);
                return Ok(usersDto);
            }
            catch (Exception ex)
            {
                throw;
            }

            finally
            {

            }


        }
        #endregion

        #region GetUserProfileById
        /// <summary>
        /// this action is used to get users by Id
        /// </summary>
        /// <returns></returns>

        // GET: api/UserProfiles/5
        [Authorize]
        [HttpGet("{id}")]

        public async Task<ActionResult<GetUserDto>> GetUserProfile(int id)
        {
            try
            {

                var userProfile = await _Service.GetUserById(id);

                if (userProfile == null)
                {
                    return NotFound();
                }
                var userDto = mapper.Map<GetUserDto>(userProfile);
                return userDto;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion

        #region UpdateUserProfile
        /// <summary>
        /// this action is used to update user profile
        /// </summary>
        /// <returns></returns>

        // PUT: api/UserProfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]

        public async Task<IActionResult> PutUserProfile(int id, UpdateUserDto userProfileDto)
        {
            try
            {

                var userProfile = await _Service.GetUserById(id);
                if (userProfile == null)
                {
                    return NotFound();
                }


                mapper.Map(userProfileDto, userProfile);


                if (_Service == null)
                {
                    return Problem("Entity set 'CropDealContext.UserProfiles'  is null.");
                }

                var val = await _Service.UpdateUser(userProfile);
                if (val == null)
                {
                    return BadRequest();
                }
                return NoContent();


            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion

        #region RegisterUserProfile
        /// <summary>
        /// this action is used to post the User
        /// </summary>
        /// <returns></returns>

        // POST: api/UserProfiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserProfile>> PostUserProfile(CreateUserDto userProfileDto)
        {
            try
            {
                if ( UserProfileExists(userProfileDto))
                {
                    return BadRequest("User Already Exists");

                }

                if (_Service == null)
                {
                    return Problem("Entity set 'CropDealContext.UserProfiles'  is null.");
                }
                var res = await _RegisterService.RegisterUser(userProfileDto);
                if (res == null)
                {
                    return BadRequest();
                }

                return Ok(res);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally { }
        }
        #endregion

        #region DeleteUser
        /// <summary>
        /// this action is used to deleta a user,
        /// </summary>
        /// <returns></returns>

        // DELETE: api/UserProfiles/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserProfile(int id)
        {
            try
            {
                if (_Service == null)
                {
                    return NotFound();
                }
                var userProfile = await _Service.GetUserById(id);
                if (userProfile == null)
                {
                    return NotFound();
                }

                var result = _Service.DeleteUser(userProfile);
                if (result == null)
                {
                    return BadRequest();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion

        #region UserExists
        /// <summary>
        /// this action is used to check if the user exists
        /// </summary>
        /// <returns></returns>

        private   bool UserProfileExists(CreateUserDto email)
        {
            try
            {
                return  _RegisterService.UserExisits(email);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion
    }
}
