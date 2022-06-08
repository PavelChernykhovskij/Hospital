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
    public class DoctorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepos<Doctor> _repository;

        public DoctorController(
            IMapper mapper,
            IRepos<Doctor> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var data = _repository.Read();
            var dtos = data.Select(_mapper.Map<DoctorDto>).ToList();
            return Json(dtos);
        }

        [HttpPost]
        public ActionResult Create(DoctorDto dto)
        {
            var data = _mapper.Map<Doctor>(dto);
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
        public ActionResult Update(Doctor data)
        {
            var rule = _mapper.Map<DoctorDto>(data);
            _repository.Update(data);
            return Json(rule);
        }
    }
}
