using AutoMapper;
using EMR.Data.Model.Exception;
using EMR.Data.Model.User;
using EMR.Common.Extension;
using EMR.Services.Interfaces;
using EMR.UnitOfWork.Interfaces;
using System.Net;

namespace EMR.Services.Services
{
    public class AuthService : IAuthService
    {
        #region Properties

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        #endregion Properties

        #region Constuctor

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constuctor

        #region Service Methods

        public async Task<UserDetailModel> Authenticate(string emailAddress, string password)
        {
            using (var context = _unitOfWork.Create())
            {
                var user = await context.Repositories.UserRepository.GetDetails(emailAddress);

                if (user.EmailAddress != null)
                {
                    var hashPassword = password.GenerateHash(user.PasswordSalt);
                    if (!string.Equals(hashPassword, user.PasswordHash))
                    {
                        BusinessException exception = new BusinessException(HttpStatusCode.Forbidden);
                        exception.AddErrorDetail("AUTH001", "Please enter a valid password.");
                        throw exception;
                    }
                }
                else
                {
                    BusinessException exception = new BusinessException(HttpStatusCode.NotFound);
                    exception.AddErrorDetail("AUTH002", "'" + emailAddress + "' does not registered with Abhighya EMR.");
                    throw exception;
                }

                return _mapper.Map<UserDetailModel>(user);
            }
        }

        #endregion Service Methods
    }
}
