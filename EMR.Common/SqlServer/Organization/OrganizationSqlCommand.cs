namespace EMR.Common.SqlServer.Organization
{
    public static class OrganizationSqlCommand
    {
        public static string GET_ORGANIZATION_BY_ID = "SELECT * FROM \"Organization\".\"OrganizationDetails\" WHERE \"OrganizationDetailId\" = " + OrganizationSqlParams.OrganizationDetailId;
        public static string SEARCH_ORGANIZATION = "SELECT * FROM \"Organization\".\"OrganizationDetails\" WHERE " +
                                                   "\"OrganizationName\" LIKE COALESCE (" + OrganizationSqlParams.OrganizationName + ", \"OrganizationName\")" +
                                                   " AND \"OrganizationTypeId\" = COALESCE (" + OrganizationSqlParams.OrganizationTypeId + ", \"OrganizationTypeId\")";
        public static string DELETE_ORGANIZATION_BY_ID = "UPDATE \"Organization\".\"OrganizationDetails\" SET \"IsActive\" = false WHERE \"OrganizationDetailId\" = " + OrganizationSqlParams.OrganizationDetailId + ";";
        public static string ADD_ORGANIZATION = "INSERT INTO \"Organization\".\"OrganizationDetails\" (\"OrganizationName\", \"AddressLine1\", \"AddressLine2\", \"City\", \"StateCode\", \"CountryId\", \"PinCode\", \"CellNo\", \"FormCNumber\", \"PanCardNumber\", \"GSTIN\", \"OrganizationTypeId\") " +
                                                 "VALUES (" + OrganizationSqlParams.OrganizationName + ", " + OrganizationSqlParams.AddressLine1 + ", " + OrganizationSqlParams.AddressLine2 + ", " + OrganizationSqlParams.City + ", " + OrganizationSqlParams.StateCode + ", " + OrganizationSqlParams.CountryId + ", " + OrganizationSqlParams.PinCode +
                                                          ", " + OrganizationSqlParams.CellNo + ", " + OrganizationSqlParams.FormCNumber + ", " + OrganizationSqlParams.PanCardNumber + ", " + OrganizationSqlParams.GSTIN + ", " + OrganizationSqlParams.OrganizationTypeId + ");";
        public static string UPDATE_ORGANIZATION = "UPDATE \"Organization\".\"OrganizationDetails\" " +
                                                    "SET \"OrganizationName\" = " + OrganizationSqlParams.OrganizationName + ", " +
                                                        "\"AddressLine1\" = " + OrganizationSqlParams.AddressLine1 + ", " +
                                                        "\"AddressLine2\" = " + OrganizationSqlParams.AddressLine2 + ", " +
                                                        "\"City\" = " + OrganizationSqlParams.City + ", " +
                                                        "\"StateCode\" = " + OrganizationSqlParams.StateCode + ", " +
                                                        "\"CountryId\" = " + OrganizationSqlParams.CountryId + ", " +
                                                        "\"PinCode\" = " + OrganizationSqlParams.PinCode + ", " +
                                                        "\"CellNo\" = " + OrganizationSqlParams.CellNo + ", " +
                                                        "\"FormCNumber\" = " + OrganizationSqlParams.FormCNumber + ", " +
                                                        "\"PanCardNumber\" = " + OrganizationSqlParams.PanCardNumber + ", " +
                                                        "\"GSTIN\" = " + OrganizationSqlParams.GSTIN + ", " +
                                                        "\"OrganizationTypeId\" = " + OrganizationSqlParams.OrganizationTypeId + ", " +
                                                        "\"RowUpdateStamp\" = " + CommonParams.RowUpdateStamp + ", " +
                                                        "\"RowUpdateUserId\" = " + CommonParams.RowUpdateUserId +
                                                    " WHERE \"OrganizationDetailId\" = " + OrganizationSqlParams.OrganizationDetailId + ";";
    }
}
