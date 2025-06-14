namespace QuizSystem.Models.ViewModels.Choice
{
    public class ChoiceVM
    {
        public string Description { get; set; }
        public bool IsTheRightAnswer { get; set; }

        public int QuestionId { get; set; }
    }
}
