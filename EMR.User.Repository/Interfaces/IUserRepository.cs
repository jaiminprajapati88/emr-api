using EMR.Data.Context;
using EMR.Data.Model.User.Request;

namespace EMR.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDetail>> GetAll();
        Task<IEnumerable<UserDetail>> Search(SearchUserRequestModel search);
        Task<UserDetail> GetDetails(string emailAddress);
        Task<bool> Save(UserDetail user);
        Task<bool> ResetPassword(string emailAddress, string newPassword);
    }
}
