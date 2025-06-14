using QuizSystem.Models.Enums;

namespace QuizSystem.Models.ViewModels.Error
{
    public class ResponseVM<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ErrorCode errorCode { get; set; }
    }
}
