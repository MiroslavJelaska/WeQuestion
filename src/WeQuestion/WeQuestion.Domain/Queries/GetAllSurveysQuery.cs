using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WeQuestion.Data;
using WeQuestion.Data.Entities;
using WeQuestion.Domain.Mappers;
using dto = WeQuestion.Domain.Dto;


namespace WeQuestion.Domain.Queries
{
    public class GetAllSurveysQuery
    {
        public GetAllSurveysQuery(WeQuestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly WeQuestionDbContext _dbContext;

        public IReadOnlyCollection<dto::Survey.ShortDetails> Execute(dto.SurvayState? state = null)
        {
            Expression<Func<Survey, bool>> filterByState = survey =>
                survey.State == SurvayState.Provisional && 
                    state.Value == dto.SurvayState.Provisional
                || 
                survey.State == SurvayState.Published && (
                    ((!survey.ClosingTimestamp.HasValue || survey.ClosingTimestamp.Value < DateTime.UtcNow) && state.Value == dto.SurvayState.Closed) ||
                    (survey.ClosingTimestamp.HasValue && DateTime.UtcNow < survey.ClosingTimestamp.Value && state.Value == dto.SurvayState.Open)
                );

            Expression<Func<Survey, bool>> ignoreStateFilter = survey => true;
            var stateFilter = state.HasValue ? filterByState : ignoreStateFilter;

            return 
                _dbContext.Surveys
                .Where(stateFilter)
                .ToList()
                .Select(SurveyMapper.ShortDetails.Map)
                .ToList();
        }
    }
}
