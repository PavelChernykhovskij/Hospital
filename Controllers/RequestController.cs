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
    public class RequestController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepos<Request> _repository;

        public RequestController(
            IMapper mapper,
            IRepos<Request> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var data = _repository.Read();
            var dtos = data.Select(_mapper.Map<RequestDto>).ToList();
            return Json(dtos);
        }

        [HttpPost]
        public ActionResult Create(RequestDto dto)
        {
            var data = _mapper.Map<Request>(dto);
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
        public ActionResult Update(Request data)
        {
            var rule = _mapper.Map<RequestDto>(data);
            _repository.Update(data);
            return Json(rule);
        }
    }
}


