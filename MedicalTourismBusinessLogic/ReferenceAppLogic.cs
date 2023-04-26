using MedicalTourismDataLayer;
using MedicalTourismDataLayer.DataModels;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTourismBusinessLogic
{
    public class ReferenceAppLogic
    {
        public ReferenceModel getAllReferences()         
        {
            ReferenceModel referenceModels = new ReferenceModel();

            string sql = "SELECT \"PreferenceId\", \"PreferenceValue\", \"PreferenceDesc\", \"IsActive\", \"IsConfig\", \"RowAddStamp\", \"RowAddUserId\", \"RowUpdateStamp\", \"RowUpdateUserId\"\r\n\tFROM \"Config\".\"AppPreference\";";

            using (var command = new NpgsqlCommand(sql))
            {
                referenceModels.appPreferenceModels = new AzurePostgresDataLayer().getData<AppPreferenceModel>(sql);
            }

            sql = "SELECT \"MessageId\", \"MessageDesc\", \"MessageTypeCode\", \"IsActive\", \"RowAddStamp\", \"RowAddUserId\", \"RowUpdateStamp\", \"RowUpdateUserId\"\r\n\tFROM \"Config\".\"Message\";";

            using (var command = new NpgsqlCommand(sql))
            {
                referenceModels.messageModels = new AzurePostgresDataLayer().getData<MessageModel>(sql);
            }

            sql = "SELECT \"StateCode\", \"StateName\"\r\n\tFROM \"Config\".\"State\";";

            using (var command = new NpgsqlCommand(sql))
            {
                referenceModels.StateModels = new AzurePostgresDataLayer().getData<StateModel>(sql);
            }

            sql = "SELECT \"TypeGroupCode\", \"TypeGroupDesc\", \"IsActive\", \"RowAddStamp\", \"RowAddUserId\", \"RowUpdateStamp\", \"RowUpdateUserId\"\r\n\tFROM \"Config\".\"TypeGroup\";";

            using (var command = new NpgsqlCommand(sql))
            {
                referenceModels.typeGroupModels = new AzurePostgresDataLayer().getData<TypeGroupModel>(sql);
            }

            foreach (var row in referenceModels.typeGroupModels)
            {
                sql = "SELECT \"TypeCode\", \"TypeGroupCode\", \"TypeDesc\", \"TypeFullDesc\", \"Sequence\", \"IsActive\", \"RowAddStamp\", \"RowAddUserId\", \"RowUpdateStamp\", \"RowUpdateUserId\"\r\n\tFROM \"Config\".\"TypeRef\";";

                using (var command = new NpgsqlCommand(sql))
                {
                   row.typeRef = new AzurePostgresDataLayer().getData<TypeRef>(sql);
                }
            }

            return referenceModels;
        }
    }
}
