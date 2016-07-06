using System.Collections.Generic;
using System.Web.Http;
using WeQuestion.Domain.Dto;
using WeQuestion.Domain.Repository;

namespace WeQuestion.Web.Controllers
{
    [RoutePrefix("api/surveys")]
    public class SurveyController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Poll> All()
        {
            return new GetAllPolls().Get();
        }
    }
}
