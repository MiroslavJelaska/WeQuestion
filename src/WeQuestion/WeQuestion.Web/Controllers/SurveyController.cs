using System.Collections.Generic;
using System.Web.Http;
using WeQuestion.Data.Entities;
using WeQuestion.Domain.Repository;
using Survey = WeQuestion.Domain.Dto.Survey;

namespace WeQuestion.Web.Controllers
{
    [RoutePrefix("api/surveys")]
    public class SurveyController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Survey> All(SurvayState? state)
        {
            return new GetAllSurveys().Execute(state);
        }
    }
}
