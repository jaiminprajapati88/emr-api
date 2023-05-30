using EMR.Common.Constant.Error;
using EMR.Common.Extension;
using System.Net;

namespace EMR.Data.Model.Exception
{
    public class UnhandledException : BaseException
    {
        #region Properties

        #endregion Properties

        #region Constuctor

        public UnhandledException(HttpStatusCode statusCode, ErrorDisplay messageDisplay = ErrorDisplay.Toaster) : base(statusCode)
        {
            MessageDisplay = messageDisplay.ToDescription();
            base.AddErrorDetail();
        }

        #endregion Constuctor
    }
}
