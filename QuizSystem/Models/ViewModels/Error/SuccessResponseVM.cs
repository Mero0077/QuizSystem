using QuizSystem.Models.Enums;

namespace QuizSystem.Models.ViewModels.Error
{
    public class SuccessResponseVM<T>:ResponseVM<T>
    {
        public SuccessResponseVM(T Data,string message="")
        {
            this.Data = Data;
            this.Message = message;
            IsSuccess = true;
            errorCode=ErrorCode.NoError;
        }
    }
}
