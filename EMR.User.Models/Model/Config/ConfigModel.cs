using EMR.Data.Context;

namespace EMR.Data.Model.Config;

public class ConfigModel
{
    public List<AppPreferenceModel> AppPreferences { get; set; }
    public IEnumerable<CityModel> Cities{ get; set; }
    public IEnumerable<StateModel> States { get; set; }
    public IEnumerable<CountryModel> Countries { get; set; }
    public IEnumerable<MessageModel> Messages { get; set; }
    public IEnumerable<TypeGroupModel> TypeGroups { get; set; }
    public IEnumerable<TypeRefModel> TypeRefs { get; set; }

    public ConfigModel()
    {
        AppPreferences = new List<AppPreferenceModel>();
        Cities = new List<CityModel>();
        States = new List<StateModel>();
        Countries = new List<CountryModel>();
        Messages = new List<MessageModel>();
        TypeGroups = new List<TypeGroupModel>();
        TypeRefs = new List<TypeRefModel>();
    }
}
