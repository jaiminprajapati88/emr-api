using EMR.Common.Constant.API;
using EMR.Data.Model.Patient.Request;
using EMR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMR.WebAPI.Controllers
{
    [Route(PatientAPI.BASE_URL)]
    [ApiController]
    public class PatientController : Controller
    {
        #region Properties

        private readonly IPatientService _patientService;

        #endregion Properties

        #region Constuctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="patientService"></param>
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        #endregion Constuctor

        /// <summary>
        /// Get all the patients by organization id
        /// </summary>
        /// <param name="organizationDetailId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(PatientAPI.GET_ALL_BY_ORG)]
        public async Task<IActionResult> GetAllByOrganization(Guid organizationDetailId)
        {
            return Ok(
                await _patientService.GetPatientsByOrganization(organizationDetailId)
            );
        }

        /// <summary>
        /// Search patients
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(PatientAPI.SEARCH)]
        public async Task<IActionResult> Search([FromBody] SearchPatientRequestModel model)
        {
            return Ok(
               await _patientService.Search(model)
            );
        }

        /// <summary>
        /// Add or update patient details
        /// </summary>
        /// <param name="organizationDetailId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SavePatientRequestModel model)
        {
            var result = await _patientService.Save(model);
            return model.PatientDetailId == Guid.Empty ? new ObjectResult(true) { StatusCode = StatusCodes.Status201Created } : Ok(result);
        }

        /// <summary>
        /// Get patient details by id
        /// </summary>
        /// <param name="patientDetailId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(PatientAPI.GET_DETAIL_BY_ID)]
        public async Task<IActionResult> GetDetails(Guid patientDetailId)
        {
            return Ok(
                await _patientService.GetDetails(patientDetailId)
            );
        }
    }
}
