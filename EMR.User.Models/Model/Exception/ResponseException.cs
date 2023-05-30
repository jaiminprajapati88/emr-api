using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EMR.Data.Model.Exception
{
    public class ResponseException
    {
        #region Properties

        [JsonIgnore]
        public HttpStatusCode StatusCode { get; private set; }
        public bool? UnhandledFault { get; private set; }
        public bool? BusinessFault { get; private set; }
        public bool? SecutiryFault { get; private set; }
        public bool? LogoutUser { get; private set; }
        public string MessageDisplay { get; set; }
        public List<ErrorDetailModel> ErrorDetails { get; set; }
        public string ErrorId { get; set; }
        public DateTime? ErrorTimeStamp { get; private set; }

        #endregion Properties

        #region Constructor

        public ResponseException() { }

        public ResponseException(UnhandledException exception)
        {
            UnhandledFault = true;
            SecutiryFault = null;
            BusinessFault = null;

            SetProperties(exception);
        }

        public ResponseException(SecurityException exception)
        {
            SecutiryFault = true;
            BusinessFault = null;
            UnhandledFault = null;

            SetProperties(exception);
        }

        public ResponseException(BusinessException exception)
        {
            BusinessFault = true;
            UnhandledFault = null;
            SecutiryFault = null;

            SetProperties(exception);
        }

        #endregion Constructor

        #region Private Methods

        private void SetProperties(BaseException exception)
        {
            StatusCode = exception.StatusCode;
            LogoutUser = exception.LogoutUser;
            MessageDisplay = exception.MessageDisplay;
            ErrorId = exception.ErrorId;
            ErrorDetails = exception.ErrorDetails;
            ErrorTimeStamp = exception.ErrorTimeStamp;
        }

        #endregion Private Methods
    }
}
