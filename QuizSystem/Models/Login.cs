using System.ComponentModel.DataAnnotations;

namespace QuizSystem.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
