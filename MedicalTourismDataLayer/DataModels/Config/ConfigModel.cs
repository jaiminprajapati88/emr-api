namespace MedicalTourismDataLayer.DataModels.Config
{
    public class ConfigModel
    {
        public List<AppPreferenceModel> AppPreferences { get; set; } = new List<AppPreferenceModel>();
        public List<StateModel> States { get; set; } = new List<StateModel>();
        public List<MessageModel> Messages { get; set; } = new List<MessageModel>();
        public List<TypeGroupModel> TypeGroups { get; set; } = new List<TypeGroupModel>();
        public List<TypeRefModel> TypeRefs { get; set; } = new List<TypeRefModel>();
    }
}
