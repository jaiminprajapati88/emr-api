using EMR.Common.Constant.Error;
using System.Net;
using System.Text.Json.Serialization;

namespace EMR.Data.Model.Exception
{
    public abstract class BaseException : System.Exception
    {
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; private set; }
        public string MessageDisplay { get; set; }
        public List<ErrorDetailModel>? ErrorDetails { get; set; }
        public string ErrorId { get; set; }
        public DateTime? ErrorTimeStamp { get; private set; }
        public bool? LogoutUser { get; protected set; }

        public BaseException(HttpStatusCode statusCode)   
        {
            StatusCode = statusCode;
            ErrorDetails = new List<ErrorDetailModel>();
            ErrorId = Guid.NewGuid().ToString("N");
            ErrorTimeStamp = DateTime.Now;
            LogoutUser = null;
        }

        public void AddErrorDetail(string errorCode = ErrorConstant.DefaultErrorCode, string errorMessage = ErrorConstant.DefaultErrorMessage)
        {
            ErrorDetails = ErrorDetails == null ? new List<ErrorDetailModel>() : ErrorDetails;
            ErrorDetails.Add(new ErrorDetailModel(errorCode, errorMessage));
        }
    }
}
