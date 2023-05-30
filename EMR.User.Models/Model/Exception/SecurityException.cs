using EMR.Common.Constant.Error;
using EMR.Common.Extension;
using System.Net;

namespace EMR.Data.Model.Exception
{
    public class SecurityException : BaseException
    {
        #region Properties
        public bool SecutiryFault { get; private set; }

        #endregion Properties

        #region Constuctor

        public SecurityException(HttpStatusCode statusCode, ErrorDisplay messageDisplay = ErrorDisplay.Toaster) : base(statusCode)
        {
            SecutiryFault = true;
            MessageDisplay = messageDisplay.ToDescription();
        }

        public SecurityException(HttpStatusCode statusCode, List<ErrorDetailModel>? errorDetails = null): base(statusCode)
        {
            SecutiryFault = true;
            ErrorDetails = errorDetails;
            MessageDisplay = ErrorDisplay.Toaster.ToDescription();
            LogoutUser = errorDetails?.Any(error => error.ErrorCode == "SEC001");
        }

        #endregion Constuctor
    }
}
