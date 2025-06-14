using QuizSystem.Models.Enums;

namespace QuizSystem.Models.ViewModels.Error
{
    public class FailureResponseVM<T>:ResponseVM<T>
    {
        public FailureResponseVM( ErrorCode errorCode,string message = "")
        {
            this.Message = message;
            IsSuccess = false;
            this.errorCode = errorCode;
        }
    }
}
