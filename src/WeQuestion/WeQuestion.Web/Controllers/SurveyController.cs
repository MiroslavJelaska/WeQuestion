﻿using System.Collections.Generic;
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
            GetAllSurveysQuery  getAllSurveysQuery,
            GetSurveyQuery      getSurveyQuery,
            CreateSurvayCommand createSurvayCommand)
        {
            _getAllSurveysQuery  = getAllSurveysQuery;
            _getSurveysQuery     = getSurveyQuery;
            _createSurvayCommand = createSurvayCommand;
        }

        private readonly GetAllSurveysQuery  _getAllSurveysQuery;
        private readonly GetSurveyQuery      _getSurveysQuery;
        private readonly CreateSurvayCommand _createSurvayCommand;

        [HttpGet]
        [Route("")]
        public IEnumerable<dto::Survey.ShortDetails> All(SurvayState? state)
        {
            return _getAllSurveysQuery.Execute(state);
        }

        [HttpGet]
        [Route("{id:int}")]
        public dto::Survey.LongDetails Get(int id)
        {
            return _getSurveysQuery.Execute(id);
        }

        [HttpPost]
        [Route("")]
        public dto::Survey.ShortDetails Create(dto::Survey.Create createSurvey)
        {
            return _createSurvayCommand.Execute(createSurvey);
        }
    }
}
