using EMR.Repository.Core;
using EMR.Repository.Interfaces;
using EMR.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EMR.Repository.SqlServer
{
    public class ConfigRepository : BaseRepository, IConfigRepository
    {
        #region Constuctor

        public ConfigRepository(EmrContext context) : base(context) { }

        #endregion Constuctor

        #region Repository Methods

        public async Task<IEnumerable<AppPreference>> GetAppPreferences()
        {
            return await base.GetAll<AppPreference>();
        }
        public async Task<IEnumerable<City>> GetCities()
        {
            return await base.GetAll<City>();
        }
        public async Task<IEnumerable<State>> GetStates()
        {
            return await base.GetAll<State>();
        }
        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await base.GetAll<Country>();
        }
        public async Task<IEnumerable<Message>> GetMessages()
        {
            return await base.GetAll<Message>();
        }
        public async Task<IEnumerable<TypeGroup>> GetTypeGroups()
        {
            return await base.GetAll<TypeGroup>();
        }
        public async Task<IEnumerable<TypeRef>> GetTypeRefs()
        {
            return await base.GetAll<TypeRef>();
        }

        public async Task<IEnumerable<AppPreference>> GetAppConfigPreferences()
        {
            return await base.Search<AppPreference>(preference => preference.IsConfig == true);
        }

        #endregion Repository Methods

        #region Private Methods

        #endregion Private Methods
    }
}
