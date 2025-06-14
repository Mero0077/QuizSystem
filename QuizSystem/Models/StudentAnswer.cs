using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace QuizSystem.Models
{
    public class StudentAnswer:BaseModel
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public int ChoiceId { get; set; }
        public DateTime? AnsweredAt { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public Choice Choice { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public Question Question { get; set; }
        
    }
}
