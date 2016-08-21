using System.Collections.Generic;
using System.Web.Http;
using WeQuestion.Common.Auth;
using WeQuestion.Domain.Commands;
using WeQuestion.Domain.Queries;
using dto = WeQuestion.Domain.Dto;

namespace WeQuestion.Web.Controllers
{
    [AllowRole(Role = UserRoleType.Admin)]
    [RoutePrefix("api/surveys")]
    public class SurveyController : AuthorizedApiController
    {
        public SurveyController(
            GetAllSurveysQuery   getAllSurveysQuery,
            GetSurveyQuery       getSurveyQuery,
            GetSurveyResultQuery getSurveyResultQuery,
            CreateSurvayCommand  createSurvayCommand,
            UpdateSurvayCommand  updateSurvayCommand,
            PublishSurveyCommand publishSurveyCommand,
            CloseSurvayCommand   closeSurvayCommand)
        {
            _getAllSurveysQuery   = getAllSurveysQuery;
            _getSurveysQuery      = getSurveyQuery;
            _getSurveyResultQuery = getSurveyResultQuery;
            _createSurvayCommand  = createSurvayCommand;
            _updateSurvayCommand  = updateSurvayCommand;
            _publishSurveyCommand = publishSurveyCommand;
            _closeSurveyCommand   = closeSurvayCommand;
        }

        private readonly GetAllSurveysQuery    _getAllSurveysQuery;
        private readonly GetSurveyQuery        _getSurveysQuery;
        private readonly GetSurveyResultQuery  _getSurveyResultQuery;
        private readonly CreateSurvayCommand   _createSurvayCommand;
        private readonly UpdateSurvayCommand   _updateSurvayCommand;
        private readonly PublishSurveyCommand  _publishSurveyCommand;
        private readonly CloseSurvayCommand    _closeSurveyCommand;

        [HttpGet]
        [Route("")]
        public IEnumerable<dto::Survey.ShortDetails> All(dto.SurvayState? state)
        {
            return _getAllSurveysQuery.Execute(state);
        }

        [HttpGet]
        [Route("{id:int}")]
        public dto::Survey.LongDetails Get(int id)
        {
            return _getSurveysQuery.Execute(id);
        }

        [HttpGet]
        [Route("{id:int}/result")]
        public dto::Survey.Result GetResult(int id)
        {
            return _getSurveyResultQuery.Execute(id);
        }

        [HttpPost]
        [Route("")]
        public dto::Survey.ShortDetails Create(dto::Survey.Create createSurvey)
        {
            return _createSurvayCommand.Execute(createSurvey);
        }

        [HttpPut]
        [Route("{id:int}")]
        public dto::Survey.LongDetails Update(dto::Survey.Update updatedSurvay)
        {
            return _updateSurvayCommand.Execute(updatedSurvay);
        }

        [HttpPost]
        [Route("{id:int}/publish")]
        public dto::Survey.ShortDetails Publish(dto::Survey.Publish publishSurvay)
        {
            return _publishSurveyCommand.Execute(publishSurvay);
        }

        [HttpPost]
        [Route("{id:int}/close")]
        public dto::Survey.LongDetails Close(int id)
        {
            return _closeSurveyCommand.Execute(id);
        }
    }
}
