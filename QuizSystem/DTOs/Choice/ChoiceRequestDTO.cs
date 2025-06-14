namespace QuizSystem.DTOs.Choice
{
    public class ChoiceRequestDTO
    {
        public string Description { get; set; }
        public bool IsTheRightAnswer { get; set; }

        public int QuestionId { get; set; }
    }
}
