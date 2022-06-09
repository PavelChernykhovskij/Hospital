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
    public class QuestionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepos<Question> _repository;
        private readonly IRepos<Doctor> _repository2;
        public QuestionController(
            IMapper mapper,
            IRepos<Question> repository,
            IRepos<Doctor> repository2)
        {
            _mapper = mapper;
            _repository = repository;
            _repository2 = repository2;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var data = _repository.Read();
            var dtos = data.Select(_mapper.Map<QuestionDto>).ToList();
            return Json(dtos);
        }

        [HttpPost]
        public ActionResult Create(QuestionDto dto)
        {
            var dtos = _repository2.Read().FirstOrDefault(q => dto.QuestionnaireId == q.Id);
            _repository2.Update(dtos);
            var data = _mapper.Map<Question>(dto);
            data.QuestionnaireId = dtos.Id;
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
        public ActionResult Update(Question data)
        {
            var rule = _mapper.Map<QuestionDto>(data);
            _repository.Update(data);
            return Json(rule);
        }
    }
}

