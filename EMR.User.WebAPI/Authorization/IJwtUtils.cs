using EMR.Data.Model.User;

namespace EMR.WebAPI.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateToken(UserDetailModel user);

        UserDetailModel? ValidateToken(string token);

    }
}
