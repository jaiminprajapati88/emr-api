using EMR.Data.Context;

namespace EMR.Repository.Interfaces
{
    public interface IConfigRepository
    {
        Task<IEnumerable<AppPreference>> GetAppPreferences();
        Task<IEnumerable<City>> GetCities();
        Task<IEnumerable<State>> GetStates();
        Task<IEnumerable<Country>> GetCountries();
        Task<IEnumerable<Message>> GetMessages();
        Task<IEnumerable<TypeGroup>> GetTypeGroups();
        Task<IEnumerable<TypeRef>> GetTypeRefs();
        Task<IEnumerable<AppPreference>> GetAppConfigPreferences();
    }
}
