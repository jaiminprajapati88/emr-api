using AutoMapper;
using EMR.Data.Context;
using EMR.Data.Model.Exception;
using EMR.Data.Model.User;
using EMR.Data.Model.User.Request;
using EMR.Common.Constant;
using EMR.Common.Extension;
using EMR.Services.Interfaces;
using EMR.UnitOfWork.Interfaces;
using System.Net;

namespace EMR.Services.Services
{
    public class UserService : IUserService
    {
        #region Properties

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        #endregion Properties

        #region Constuctor

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constuctor

        #region Service Methods

        public async Task<IEnumerable<UserDetailModel>> GetAll()
        {
            using (var context = _unitOfWork.Create())
            {
                var users = await context.Repositories.UserRepository.GetAll();
                return _mapper.Map<IEnumerable<UserDetailModel>>(users);
            }
        }

        public async Task<IEnumerable<UserDetailModel>> Search(SearchUserRequestModel search)
        {
            using (var context = _unitOfWork.Create())
            {
                var users = await context.Repositories.UserRepository.Search(search);
                return _mapper.Map<IEnumerable<UserDetailModel>>(users);
            }
        }

        public async Task<bool> Save(SaveUserRequestModel user)
        {
            using (var context = _unitOfWork.Create())
            {
                var userEntity = _mapper.Map<UserDetail>(user);
                var isUpdateUser = user.UserDetailId != Guid.Empty;
                var searchModel = new SearchUserRequestModel(user.OrganizationDetailId, user.EmailAddress);
                var users = context.Repositories.UserRepository.Search(searchModel);

                if ((isUpdateUser && users.Result.Count() > 1) || (!isUpdateUser && users.Result.Count() > 0))
                {
                    BusinessException exception = new BusinessException(HttpStatusCode.Conflict);
                    exception.AddErrorDetail("USER002", "User '" + string.Join(" ", user.FirstName, user.LastName) + "' already exists.");
                    throw exception;
                }

                if (isUpdateUser)
                {
                    userEntity = users.Result.SingleOrDefault(org => org.UserDetailId == user.UserDetailId);
                    user.CopyProperties(userEntity);
                }
                else
                {
                    userEntity.PasswordSalt = SecurityConstant.KeySize.GenerateSalt();
                    userEntity.PasswordHash = user.Password.GenerateHash(userEntity.PasswordSalt);
                    userEntity.UserOrganizations.Add(new UserOrganization()
                    {
                        OrganizationDetailId = user.OrganizationDetailId                        
                    });
                }

                var result = await context.Repositories.UserRepository.Save(userEntity);
                await context.CommitTransaction();

                return result;
            }
        }

        public async Task<UserDetailModel> GetDetails(string emailAddress)
        {
            using (var context = _unitOfWork.Create())
            {
                var model = await context.Repositories.UserRepository.GetDetails(emailAddress);
                return _mapper.Map<UserDetailModel>(model);
            }
        }

        public async Task<bool> ResetPassword(string emailAddress, string newPassword)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = false;
                var newPasswordSalt = SecurityConstant.KeySize.GenerateSalt();
                var newPasswordHash = newPassword.GenerateHash(newPasswordSalt);
                var userDetail = await context.Repositories.UserRepository.GetDetails(emailAddress);

                if (userDetail != null)
                {
                    userDetail.PasswordHash = newPasswordHash;
                    userDetail.PasswordSalt = newPasswordSalt;

                    result = await context.Repositories.UserRepository.Save(userDetail);
                    await context.CommitTransaction();
                }

                return result;
            }
        }

        #endregion Service Methods
    }
}
