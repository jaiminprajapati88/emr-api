using MedicalTourismBusinessLogic;
using MedicalTourismDataLayer.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTourismConfig.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        [HttpGet(Name = "ReferenceAppLogic")]
        public ReferenceModel Get()
        {
           return new ReferenceAppLogic().getAllReferences();
        }
    }
}