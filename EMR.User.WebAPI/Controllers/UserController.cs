using EMR.Common.Constants.API;
using EMR.Data.Model.Auth.Request;
using EMR.Data.Model.Config;
using EMR.Data.Model.User;
using EMR.Data.Model.User.Request;
using EMR.Services.Interfaces;
using EMR.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace EMR.User.WebAPI.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    [Route(UserAPI.BASE_URL)]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Properties

        private readonly IUserService _userService;

        #endregion Properties

        #region Constuctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion Constuctor

        #region Controller API

        /// <summary>
        /// Get all the registered users in the application
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(UserAPI.GET_ALL)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(
                await _userService.GetAll()
            );
        }

        /// <summary>
        /// Get user details by email address
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(UserAPI.GET_DETAIL_BY_EMAIL)]
        public async Task<IActionResult> GetUserDetailsByEmail(string emailAddress)
        {
            return Ok(
               await _userService.GetDetails(emailAddress)
            );
        }

        /// <summary>
        /// Search users
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(UserAPI.SEARCH)]
        public async Task<IActionResult> SearchUsers([FromBody] SearchUserRequestModel model)
        {
            return Ok(
               await _userService.Search(model)
            );
        }

        /// <summary>
        /// Add new or update existing organization user details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(UserAPI.SAVE)]
        public async Task<IActionResult> SaveUser([FromBody] SaveUserRequestModel model)
        {
            var result = await _userService.Save(model);
            return model.UserDetailId == null ? new ObjectResult(true) { StatusCode = StatusCodes.Status201Created } : Ok(result);
        }

        /// <summary>
        /// Reset user password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(UserAPI.RESET_PASSWORD)]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestModel model)
        {
            return Ok(
               await _userService.ResetPassword(model.EmailAddress, model.NewPassword)
            );
        }

        #endregion Controller API
    }
}
