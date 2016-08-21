using System.Collections.Generic;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Domain.Dto.Survey
{
    public class Result
    {
        public int Id { get; set; }

        public int ParticipantsCount { get; set; }

        public IReadOnlyCollection<QuestionResult> QuestionsWithResults { get; set; }

        public IReadOnlyCollection<string> Comments { get; set; } 

        public class QuestionResult
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public int CorrentAnswersCount { get; set; }
            public int WrongAnswerCount { get; set; }
            public int LeftUnansweredCount { get; set; }
            public dto.Option.Details CorrectAnswerOption { get; set; }
        }
    }
}
