namespace EMR.Common.SqlServer.Config
{
    public static class ConfigSqlCommand
    {
        public static string GET_ALL_PREFERENCES = "SELECT * FROM \"Config\".\"AppPreference\"";
        public static string GET_ALL_MESSAGES = "SELECT * FROM \"Config\".\"Message\"";
        public static string GET_ALL_CITIES = "SELECT * FROM \"Config\".\"City\"";
        public static string GET_ALL_STATES = "SELECT * FROM \"Config\".\"State\"";
        public static string GET_ALL_COUNTRIES = "SELECT * FROM \"Config\".\"Country\"";
        public static string GET_ALL_TYPEGROUPS = "SELECT * FROM \"Config\".\"TypeGroup\"";
        public static string GET_ALL_TYPEREFS = "SELECT * FROM \"Config\".\"TypeRef\"";
        public static string GET_CONFIG_PREFERENCES = "SELECT * FROM \"Config\".\"AppPreference\" WHERE \"IsConfig\" = " + CommonParams.IsConfig + " AND \"IsActive\" = " + CommonParams.IsActive;
    }
}
