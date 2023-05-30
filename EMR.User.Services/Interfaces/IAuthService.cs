using EMR.Data.Model.User;

namespace EMR.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserDetailModel> Authenticate(string emailAddress, string password);
    }
}
