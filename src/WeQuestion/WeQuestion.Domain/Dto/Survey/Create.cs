using dto = WeQuestion.Domain.Dto;
namespace WeQuestion.Domain.Dto.Survey
{
    public class Create
    {
        public string Title { get; set; }

        public dto::Question.Create Question { get; set; }
    }
}
