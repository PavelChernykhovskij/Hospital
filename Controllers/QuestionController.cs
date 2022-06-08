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

        public QuestionController(
            IMapper mapper,
            IRepos<Question> repository)
        {
            _mapper = mapper;
            _repository = repository;
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
            var data = _mapper.Map<Question>(dto);
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

