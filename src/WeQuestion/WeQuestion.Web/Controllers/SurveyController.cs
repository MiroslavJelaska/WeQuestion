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
        public SurveyController(GetAllSurveysQuery getAllSurveysQuery)
        {
            _getAllSurveysQuery = getAllSurveysQuery;
        }

        private readonly GetAllSurveysQuery _getAllSurveysQuery;

        [HttpGet]
        [Route("")]
        public IEnumerable<dto::Survey.ShortDetails> All(SurvayState? state)
        {
            return _getAllSurveysQuery.Execute(state);
        }
    }
}
