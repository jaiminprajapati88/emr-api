using EMR.Common.Constant.Error;
using EMR.Common.Extension;
using System.Net;

namespace EMR.Data.Model.Exception
{
    public class BusinessException : BaseException
    {
        #region Properties

        public bool BusinessFault { get; private set; }

        #endregion Properties

        #region Constuctor

        public BusinessException(HttpStatusCode statusCode, ErrorDisplay messageDisplay = ErrorDisplay.Toaster) : base(statusCode)
        {
            BusinessFault = true;
            MessageDisplay = messageDisplay.ToDescription();
        }

        #endregion Constuctor
    }
}
