namespace QuizSystem.DTOs.Choice
{
    public class ChoiceUpdateRequestDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsTheRightAnswer { get; set; }

        public int QuestionId { get; set; }
    }
}
