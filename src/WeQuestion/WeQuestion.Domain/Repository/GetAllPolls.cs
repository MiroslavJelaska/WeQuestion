using System.Collections.Generic;
using System.Linq;
using WeQuestion.Data;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Domain.Repository
{
    public class GetAllPolls
    {
        public IReadOnlyCollection<dto::Poll> Get()
        {
            using (var dbContext = new WeQuestionDbContext())
            {
                return 
                    dbContext.Polls.ToList().Select(x => new dto::Poll() {Id = x.Id, Text = x.Title }).ToList();
            }
        }
    }
}
