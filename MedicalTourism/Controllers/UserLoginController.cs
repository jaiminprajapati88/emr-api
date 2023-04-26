using MedicalTourismBusinessLogic;
using MedicalTourismDataLayer.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTourism.Controllers
{
    [Route("api/[controller]")]
    [ApiController]     
    public class UserLoginController : ControllerBase
    {
        [HttpPost("UserLogin")]
        public UserLoginDBData UserLogin(UserLoginAppInData userLoginAppInData)
        {
            try
            {
                return new UserLoginBL().UserLogin(userLoginAppInData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("UserLogin")]
        public UserLoginDBData ResetPassword(UserResetPassword userLoginAppInData)
        {
            try
            {
                return new UserLoginBL().UserResetPassword(userLoginAppInData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
