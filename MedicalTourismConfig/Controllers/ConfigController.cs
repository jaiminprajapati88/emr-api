using MedicalTourismBusinessLogic;
using MedicalTourismDataLayer.DataModels.Config;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTourismConfig.Controllers
{
    [ApiController]
    [Route("api/v1/config")]
    public class ConfigController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public ConfigModel GetAllConfig()
        {
           return new ConfigAppLogic().GetAllConfigurations();
        }

        [HttpGet]
        [Route("settings")]
        public List<AppPreferenceModel> GetConfigPreferences()
        {
            return new ConfigAppLogic().GetConfigPreferences();
        }
    }
}