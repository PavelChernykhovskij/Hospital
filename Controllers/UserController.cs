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
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepos<User> _repository;

        public UserController(
            IMapper mapper,
            IRepos<User> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var data = _repository.Read();
            var dtos = data.Select(_mapper.Map<UserDto>).ToList();
            return Json(dtos);
        }

        [HttpPost]
        public ActionResult Create(UserDto dto)
        {
            var data = _mapper.Map<User>(dto);
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
        public ActionResult Update(User data)
        {
            var rule = _mapper.Map<UserDto>(data);
            _repository.Update(data);
            return Json(rule);
        }
    }
}



