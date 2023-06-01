using EMR.Common.Constant.API;
using EMR.Data.Model.Organization.Request;
using EMR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMR.WebAPI.Controllers
{
    /// <summary>
    /// Organization Controller
    /// </summary>
    [Route(OrganizationAPI.BASE_URL)]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        #region Properties

        private readonly IOrganizationService _organizationService;

        #endregion Properties

        #region Constuctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="organizationService"></param>
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        #endregion Constuctor

        #region Controller API

        /// <summary>
        /// Add new or update existing organization
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SaveOrganization([FromBody] SaveOrganizationRequestModel model)
        {
            var result = await _organizationService.Save(model);
            return model.OrganizationDetailId == null ? new ObjectResult(true) { StatusCode = StatusCodes.Status201Created } : Ok(result);
        }

        /// <summary>
        /// Delete organization by organization detail id
        /// </summary>
        /// <param name="organizationDetailId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteOrganization(Guid organizationDetailId)
        {
            return Ok(
               await _organizationService.Delete(organizationDetailId)
            );
        }

        #endregion Controller API
    }
}
