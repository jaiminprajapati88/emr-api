using System.ComponentModel;

namespace EMR.Common.Constant.Error
{
    public enum ErrorDisplay
    {
        [Description("TOASTER")]
        Toaster = 1,
        [Description("MODAL")]
        Modal = 2,
        [Description("PAGE")]
        Page = 3
    }
    public class ErrorConstant
    {
        public const string DefaultErrorCode = "SYS100";
        public const string DefaultErrorMessage = "An error has occurred while processing your request. Please try after sometime.";

    }
}
