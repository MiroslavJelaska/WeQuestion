using System.Collections.Generic;
using System.Web.Http;
using WeQuestion.Data.Entities;
using WeQuestion.Domain.Commands;
using WeQuestion.Domain.Queries;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Web.Controllers
{
    [RoutePrefix("api/surveys")]
    public class SurveyController : ApiController
    {
        public SurveyController(
            GetAllSurveysQuery getAllSurveysQuery,
            CreateSurvayCommand createSurvayCommand)
        {
            _getAllSurveysQuery = getAllSurveysQuery;
            _createSurvayCommand = createSurvayCommand;
        }

        private readonly GetAllSurveysQuery _getAllSurveysQuery;
        private readonly CreateSurvayCommand _createSurvayCommand;

        [HttpGet]
        [Route("")]
        public IEnumerable<dto::Survey.ShortDetails> All(SurvayState? state)
        {
            return _getAllSurveysQuery.Execute(state);
        }

        [HttpPost]
        [Route("")]
        public dto::Survey.ShortDetails Create(dto::Survey.Create createSurvey)
        {
            return _createSurvayCommand.Execute(createSurvey);
        }
    }
}
