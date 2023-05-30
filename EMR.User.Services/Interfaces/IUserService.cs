using EMR.Data.Model.User;
using EMR.Data.Model.User.Request;

namespace EMR.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDetailModel>> GetAll();
        Task<IEnumerable<UserDetailModel>> Search(SearchUserRequestModel search);
        Task<UserDetailModel> GetDetails(string emailAddress);
        Task<bool> Save(SaveUserRequestModel user);
        Task<bool> ResetPassword(string emailAddress, string newPassword);
    }
}
