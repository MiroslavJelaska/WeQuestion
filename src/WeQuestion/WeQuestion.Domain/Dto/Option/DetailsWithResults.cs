namespace WeQuestion.Domain.Dto.Option
{
    public class DetailsWithResults
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public int MarkedAsCorrectAnswerCount { get; set; }
    }
}
