using MedicalTourismDataLayer.DataModels.Config;
using MedicalTourismDataLayer;
using Npgsql;

namespace MedicalTourismBusinessLogic
{
    public class ConfigAppLogic
    {
        public ConfigModel GetAllConfigurations()
        {
            ConfigModel referenceModels = new ConfigModel();

            string sql = "SELECT \"PreferenceId\", \"PreferenceValue\", \"PreferenceDesc\", \"IsActive\", \"IsConfig\", \"RowAddStamp\", \"RowAddUserId\", \"RowUpdateStamp\", \"RowUpdateUserId\"\r\n\tFROM \"Config\".\"AppPreference\";";

            using (var command = new NpgsqlCommand(sql))
            {
                referenceModels.AppPreferences = new AzurePostgresDataLayer().GetData<AppPreferenceModel>(sql);
            }

            sql = "SELECT \"MessageId\", \"MessageDesc\", \"MessageTypeCode\", \"IsActive\", \"RowAddStamp\", \"RowAddUserId\", \"RowUpdateStamp\", \"RowUpdateUserId\"\r\n\tFROM \"Config\".\"Message\";";

            using (var command = new NpgsqlCommand(sql))
            {
                referenceModels.Messages = new AzurePostgresDataLayer().GetData<MessageModel>(sql);
            }

            sql = "SELECT \"StateCode\", \"StateName\"\r\n\tFROM \"Config\".\"State\";";

            using (var command = new NpgsqlCommand(sql))
            {
                referenceModels.States = new AzurePostgresDataLayer().GetData<StateModel>(sql);
            }

            sql = "SELECT \"TypeGroupCode\", \"TypeGroupDesc\", \"IsActive\", \"RowAddStamp\", \"RowAddUserId\", \"RowUpdateStamp\", \"RowUpdateUserId\"\r\n\tFROM \"Config\".\"TypeGroup\";";

            using (var command = new NpgsqlCommand(sql))
            {
                referenceModels.TypeGroups = new AzurePostgresDataLayer().GetData<TypeGroupModel>(sql);
            }

            sql = "SELECT \"TypeCode\", \"TypeGroupCode\", \"TypeDesc\", \"TypeFullDesc\", \"Sequence\", \"IsActive\", \"RowAddStamp\", \"RowAddUserId\", \"RowUpdateStamp\", \"RowUpdateUserId\"\r\n\tFROM \"Config\".\"TypeRef\";";

            using (var command = new NpgsqlCommand(sql))
            {
                referenceModels.TypeRefs = new AzurePostgresDataLayer().GetData<TypeRefModel>(sql);
            }

            return referenceModels;
        }

        public List<AppPreferenceModel> GetConfigPreferences()
        {
            List<AppPreferenceModel> appPreferences = new List<AppPreferenceModel>();

            string sql = "SELECT \"PreferenceId\", \"PreferenceValue\", \"PreferenceDesc\", \"IsActive\", \"IsConfig\", \"RowAddStamp\", \"RowAddUserId\", \"RowUpdateStamp\", \"RowUpdateUserId\"\r\n\tFROM \"Config\".\"AppPreference\" WHERE \"IsConfig\"=TRUE;";

            using (var command = new NpgsqlCommand(sql))
            {
                appPreferences = new AzurePostgresDataLayer().GetData<AppPreferenceModel>(sql);
            }

            return appPreferences;
        }
    }

}
