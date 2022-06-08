using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Hospital.Models;
using Hospital.EntityFramework.Repositories;
using Hospital.Services;
using Hospital.Dtos;

namespace Hospital.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionnaireController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepos<Questionnaire> _repository;

        public QuestionnaireController(
            IMapper mapper,
            IRepos<Questionnaire> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var data = _repository.Read();
            var dtos = data.Select(_mapper.Map<QuestionnaireDto>).ToList();
            return Json(dtos);
        }

        [HttpPost]
        public ActionResult Create(QuestionnaireDto dto)
        {
            var data = _mapper.Map<Questionnaire>(dto);
            _repository.Create(data);
            return Json(dto);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Json(id);
        }

        [HttpPost]
        public ActionResult Update(Questionnaire data)
        {
            var rule = _mapper.Map<QuestionnaireDto>(data);
            _repository.Update(data);
            return Json(rule);
        }
    }
}

