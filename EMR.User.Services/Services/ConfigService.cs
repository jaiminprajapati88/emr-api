using AutoMapper;
using EMR.Data.Context;
using EMR.Data.Model.Config;
using EMR.Services.Interfaces;
using EMR.UnitOfWork.Interfaces;

namespace EMR.Services.Services
{
    public class ConfigService : IConfigService
    {
        #region Properties

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        #endregion Properties

        #region Constuctor

        public ConfigService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constuctor

        #region Service Methods

        public ConfigModel GetAllConfig()
        {
            using (var context = _unitOfWork.Create())
            {
                ConfigModel model = new ConfigModel();

                model.AppPreferences = _mapper.Map<List<AppPreferenceModel>>(context.Repositories.ConfigRepository.GetAppPreferences().Result);
                model.Messages = _mapper.Map<List<MessageModel>>(context.Repositories.ConfigRepository.GetMessages().Result);
                model.Cities = _mapper.Map<List<CityModel>>(context.Repositories.ConfigRepository.GetCities().Result);
                model.States = _mapper.Map<List<StateModel>>(context.Repositories.ConfigRepository.GetStates().Result);
                model.Countries = _mapper.Map<List<CountryModel>>(context.Repositories.ConfigRepository.GetCountries().Result);
                model.TypeGroups = _mapper.Map<List<TypeGroupModel>>(context.Repositories.ConfigRepository.GetTypeGroups().Result);
                model.TypeRefs = _mapper.Map<List<TypeRefModel>>(context.Repositories.ConfigRepository.GetTypeRefs().Result);

                return model;
            }
        }

        public async Task<IEnumerable<AppPreference>> GetAppPreferences()
        {
            using (var context = _unitOfWork.Create())
            {
                return await context.Repositories.ConfigRepository.GetAppConfigPreferences();
            }
        }

        #endregion Service Methods
    }
}
