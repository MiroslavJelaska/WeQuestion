using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WeQuestion.Data;
using WeQuestion.Data.Entities;
using dto = WeQuestion.Domain.Dto;
using data = WeQuestion.Data.Entities;

namespace WeQuestion.Domain.Queries
{
    public class GetAllSurveysQuery
    {
        public GetAllSurveysQuery(WeQuestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly WeQuestionDbContext _dbContext;

        public IReadOnlyCollection<dto::Survey.ShortDetails> Execute(SurvayState? state = null)
        {
            Expression<Func<Survey, bool>> filterByState =survey => survey.State == state.Value;
            Expression<Func<Survey, bool>> ignoreStateFilter = survey => true;
            var stateFilter = state.HasValue ? filterByState : ignoreStateFilter;

            return 
                _dbContext.Surveys
                .Where(stateFilter)
                .ToList()
                .Select(_mapper)
                .ToList();
        }

        private dto::Survey.ShortDetails _mapper(data::Survey survey)
        {
            return new dto::Survey.ShortDetails()
            {
                Id = survey.Id,
                Title = survey.Title,
                AccessToken = survey.AccessToken,
                ClosingTimestamp = survey.ClosingTimestamp
            };
        }
    }
}
