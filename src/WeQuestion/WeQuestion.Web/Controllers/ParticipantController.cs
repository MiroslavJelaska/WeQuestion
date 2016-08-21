using System.Web.Http;
using WeQuestion.Common.Auth;
using WeQuestion.Domain.Commands;
using WeQuestion.Domain.Queries;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Web.Controllers
{
    [AllowRole(Role = UserRoleType.Anonymous)]
    [RoutePrefix("api/participation")]
    public class ParticipationController : AuthorizedApiController
    {
        public ParticipationController(
            GetSurveyQuery       getSurveyQuery,
            ParticipateSurveyCommand participateSurveyCommand)
        {
            _getSurveysQuery      = getSurveyQuery;
            _participateSurveyCommand = participateSurveyCommand;
        }

        private readonly GetSurveyQuery        _getSurveysQuery;
        private readonly ParticipateSurveyCommand _participateSurveyCommand;

        [HttpGet]
        [Route("{accessToken}")]
        public dto::Survey.LongDetails Get(string accessToken)
        {
            return _getSurveysQuery.Execute(accessToken);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Participate([FromBody] dto.Survey.Participation participation)
        {
            participation.ProvisionalUserId = AuthDetails.Id;
            _participateSurveyCommand.Execute(participation);

            return Ok();
        }
    }
}
