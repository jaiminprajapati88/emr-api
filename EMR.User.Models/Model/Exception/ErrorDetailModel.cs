using EMR.Common.Constant.Error;

namespace EMR.Data.Model.Exception
{
    public class ErrorDetailModel
    {
        #region Properties

        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public dynamic? ErrorParameters { get; set; }

        #endregion Properties

        #region Constuctor

        public ErrorDetailModel(string errorCode, string errorMessage)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
        }

        #endregion Constuctor
    }
}
