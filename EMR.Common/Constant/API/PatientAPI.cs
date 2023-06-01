using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Common.Constant.API
{
    public class PatientAPI
    {
        public const string BASE_URL = "api/v{version:apiVersion}/patient";

        public const string GET_ALL_BY_ORG = "organization";
        public const string GET_DETAIL_BY_ID = "detail";
        public const string SEARCH = "search";
    }
}
