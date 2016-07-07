using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WeQuestion.Data;
using WeQuestion.Data.Entities;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Domain.Queries
{
    public class GetAllSurveys
    {
        public IReadOnlyCollection<dto::Survey.ShortDetails> Execute(SurvayState? state = null)
        {
            Expression<Func<Survey, bool>> filterByState =survey => survey.State == state.Value;
            Expression<Func<Survey, bool>> ignoreStateFilter = survey => true;
            var stateFilter = state.HasValue ? filterByState : ignoreStateFilter;

            using (var dbContext = new WeQuestionDbContext())
            {
                return 
                    dbContext.Polls
                    .Where(stateFilter)
                    .ToList()
                    .Select(x => new dto::Survey.ShortDetails() {Id = x.Id, Title = x.Title, AccessToken = x.AccessToken, ClosingTimestamp = x.ClosingTimestamp })
                    .ToList();
            }
        }
    }
}
