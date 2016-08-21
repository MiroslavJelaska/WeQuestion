using System;
using System.Linq;
using WeQuestion.Common;
using data = WeQuestion.Data.Entities;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Domain.Mappers
{
    public static class SurveyMapper
    {
        public static class ShortDetails
        {
            public static dto::Survey.ShortDetails Map(data::Survey survey)
            {
                return new dto::Survey.ShortDetails()
                {
                    Id               = survey.Id,
                    Title            = survey.Title,
                    AccessToken      = survey.AccessToken,
                    ClosingTimestamp = survey.ClosingTimestamp,
                    DurationInMinutes = survey.DurationInMinutes,
                    State            = MapSurveyState(survey)
                };
            }
        }

        public static class LongDetails
        {
            public static dto::Survey.LongDetails Map(data::Survey survey)
            {
                return new dto::Survey.LongDetails()
                {
                    Id               = survey.Id,
                    Title            = survey.Title,
                    AccessToken      = survey.AccessToken,
                    ClosingTimestamp = survey.ClosingTimestamp,
                    DurationInMinutes =  survey.DurationInMinutes,
                    Questions        = survey.Questions.Select(QustionMapper.Map).ToList(),
                    State            = MapSurveyState(survey)
                };
            }
        }

        private static dto.SurvayState MapSurveyState(data::Survey survey)
        {
            if(survey.State == data.SurvayState.Provisional)
                return dto.SurvayState.Provisional;
            if (survey.ClosingTimestamp.HasValue && DateTimeOffset.UtcNow < survey.ClosingTimestamp.Value)
                return dto.SurvayState.Open;
            return dto.SurvayState.Closed;
        }

        public static class Result
        {
            public static dto::Survey.Result Map(data::Survey survey)
            {
                var result =
                    from question in survey.Questions
                    let participantsCount = survey.SurveyParticipations.Count
                    let correctAnswerOption = question.AnswerOptions.FirstOrDefault(answerOption => answerOption.IsCorrect)
                    let correntAnswersCount =
                        correctAnswerOption
                        .UsersAnswers
                        .Count
                    let wrongAnswerCount =
                        question.AnswerOptions
                        .Where(answerOption => !answerOption.IsCorrect)
                        .SelectMany(answerOption => answerOption.UsersAnswers)
                        .Count()
                    let leftUnansweredCount = participantsCount - (correntAnswersCount + wrongAnswerCount)
                    select new dto.Survey.Result.QuestionResult()
                    {
                        Id = question.Id,
                        Text = question.Text,
                        CorrectAnswerOption = Mappers.OptionMapper.Map(correctAnswerOption),
                        CorrentAnswersCount = correntAnswersCount,
                        WrongAnswerCount = wrongAnswerCount,
                        LeftUnansweredCount = leftUnansweredCount
                    };

                var comments =
                    survey.SurveyParticipations
                    .Select(x => x.Comment)
                    .Where(x => !Check.IsNullOrEmptyOrWhitespace(x))
                    .ToList();

                return new dto.Survey.Result() {
                    Id = survey.Id,
                    ParticipantsCount = survey.SurveyParticipations.Count,
                    QuestionsWithResults = result.ToList(),
                    Comments = comments
                };
            }
        }
    }
}
