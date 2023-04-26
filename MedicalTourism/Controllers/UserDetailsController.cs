using MedicalTourismBusinessLogic;
using MedicalTourismDataLayer.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MedicalTourism.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserDetailsController : ControllerBase
    {
        [HttpGet("~/GetUsers")]
        public List<RegisterUserRequest2> Get()
        {
            return new UserAppLogic().GetUsers();
        }

        [HttpGet("~/GetAllUser")]
        public List<RegisterUserRequest2> GetAllUser()
        {
            return new UserAppLogic().GetAllUser();
        }

        [HttpPost("CreateUser")]
        public RegisterUserRequest2 CreateUser(RegisterUserRequest registerUser)
        {
            try
            {
                return new UserAppLogic().CreateUser(registerUser);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        [HttpDelete("DeleteUser")]
        public bool DeleteUser(RegisterUserRequest registerUser)
        {
            try
            {
                new UserAppLogic().DeleteUser(registerUser);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("");
            }
        }


        [HttpPut("UpdateUser")]
        public RegisterUserRequest2 UpdateUser(RegisterUserRequest registerUser)
        {
            try
            {
                return new UserAppLogic().UpdateUser(registerUser);
            }
            catch (Exception ex)
            {
                throw new Exception("");
            }
        }
    }
}