using EMR.Data.Context;
using EMR.Data.Model.Config;

namespace EMR.Services.Interfaces
{
    public interface IConfigService
    {
        ConfigModel GetAllConfig();
        Task<IEnumerable<AppPreference>> GetAppPreferences();
    }
}
