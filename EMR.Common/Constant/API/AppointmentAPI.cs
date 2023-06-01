using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Common.Constant.API
{
    public class AppointmentAPI
    {
        public const string BASE_URL = "api/v{version:apiVersion}/appointment";

        public const string GET_ALL = "all";
        public const string SERVICE = "service";
        public const string GET_ALL_SERVICE = "service/all";
    }
}
