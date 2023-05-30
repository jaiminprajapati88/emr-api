using EMR.Common.Constants.API;
using EMR.Data.Model.Auth.Request;
using EMR.Services.Interfaces;
using EMR.WebAPI.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace EMR.WebAPI.Controllers
{
    /// <summary>
    /// Auth Controller
    /// </summary>
    [Route(AuthAPI.BASE_URL)]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Properties

        private readonly IAuthService _authService;
        private readonly IJwtUtils _jwtUtils;

        #endregion Properties

        #region Constuctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authService"></param>
        /// <param name="jwtUtils"></param>
        public AuthController(IAuthService authService, IJwtUtils jwtUtils)
        {
            _authService = authService;
            _jwtUtils = jwtUtils;
        }

        #endregion Constuctor

        #region Controller API

        /// <summary>
        /// Validate user credentials
        /// </summary>
        /// <param name="model">Specify email address and password to validate credentials</param>
        /// <returns></returns>
        [HttpPost]
        [Route(AuthAPI.SIGN_IN)]        
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateUser([FromBody] AuthenticateRequestModel model)
        {
            var user = await _authService.Authenticate(model.EmailAddress, model.Password);
            var token = _jwtUtils.GenerateToken(user);

            Response.Headers.Add("Authorization", token);

            return Ok();
        }

        #endregion Controller API
    }
}
