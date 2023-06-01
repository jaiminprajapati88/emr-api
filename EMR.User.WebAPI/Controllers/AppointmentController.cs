using EMR.Common.Constant.API;
using EMR.Data.Model.Appointment.Request;
using EMR.Data.Model.Patient.Request;
using EMR.Services.Interfaces;
using EMR.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMR.WebAPI.Controllers
{
    [Route(AppointmentAPI.BASE_URL)]
    [ApiController]
    public class AppointmentController : Controller
    {
        #region Properties

        private readonly IAppointmentService _appointmentService;

        #endregion Properties

        #region Constuctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appointmentService"></param>
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        /// <summary>
        /// Get all appointments for specific date by organization and user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(AppointmentAPI.GET_ALL)]
        public async Task<IActionResult> GetAll([FromBody]AppointmentRequestModel request)
        {
            return Ok(
                await _appointmentService.GetAll(request)
            ); ;
        }

        [HttpPost]
        [Route(AppointmentAPI.GET_ALL_SERVICE)]
        public async Task<IActionResult> GetAllService([FromBody] AppointmentServiceRequestModel request)
        {
            return Ok(
                await _appointmentService.GetAllService(request)
            ); ;
        }

        /// <summary>
        /// Add new/update existing appointment
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SaveAppointmentModel model)
        {
            var result = await _appointmentService.Save(model);
            return model.AppointmentId > 0 ? Ok(result) : new ObjectResult(true) { StatusCode = StatusCodes.Status201Created };
        }

        /// <summary>
        /// Add new/update existing appointment service
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(AppointmentAPI.SERVICE)]
        public async Task<IActionResult> SaveService([FromBody] SaveAppointmentServiceModel model)
        {
            var result = await _appointmentService.SaveService(model);
            return model.AppointmentServiceId > 0 ? Ok(result) : new ObjectResult(true) { StatusCode = StatusCodes.Status201Created };
        }

        #endregion Constuctor
    }
}
