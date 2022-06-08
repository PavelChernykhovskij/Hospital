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
    public class MedcardController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepos<Medcard> _repository;

        public MedcardController(
            IMapper mapper,
            IRepos<Medcard> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var data = _repository.Read();
            var dtos = data.Select(_mapper.Map<MedcardDto>).ToList();
            return Json(dtos);
        }

        [HttpPost]
        public ActionResult Create(MedcardDto dto)
        {
            var data = _mapper.Map<Medcard>(dto);
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
        public ActionResult Update(Medcard data)
        {
            var rule = _mapper.Map<MedcardDto>(data);
            _repository.Update(data);
            return Json(rule);
        }
    }
}
