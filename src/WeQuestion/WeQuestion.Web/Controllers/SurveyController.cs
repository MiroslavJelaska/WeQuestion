using System.Collections.Generic;
using System.Web.Http;
using WeQuestion.Data.Entities;
using WeQuestion.Domain.Queries;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Web.Controllers
{
    [RoutePrefix("api/surveys")]
    public class SurveyController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<dto::Survey.ShortDetails> All(SurvayState? state)
        {
            return new GetAllSurveys().Execute(state);
        }
    }
}
