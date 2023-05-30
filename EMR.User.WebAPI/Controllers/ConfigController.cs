using EMR.Common.Constants.API;
using EMR.Data.Context;
using EMR.Data.Model.Config;
using EMR.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMR.User.WebAPI.Controllers
{
    /// <summary>
    /// Config Controller
    /// </summary>
    [Route(ConfigAPI.BASE_URL)]
    [ApiController]
    public class ConfigController : Controller
    {
        #region Properties

        private readonly IConfigService _configService;

        #endregion Properties

        #region Constuctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configService"></param>
        public ConfigController(IConfigService configService)
        {
            _configService = configService;
        }

        #endregion Constuctor

        #region Controller API

        /// <summary>
        /// Get application level all the configurations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(ConfigAPI.GET_ALL_CONFIG)]
        public ActionResult<ConfigModel> GetAllConfig()
        {
            return Ok(
                _configService.GetAllConfig()
            );
        }

        /// <summary>
        /// Get application level preferences
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(ConfigAPI.GET_APP_PREFERENCES)]
        [AllowAnonymous]
        public async Task<IActionResult> GetAppPreferences()
        {
            var preferences = await _configService.GetAppPreferences();
            return Ok(preferences);
        }

        #endregion Controller API
    }
}
