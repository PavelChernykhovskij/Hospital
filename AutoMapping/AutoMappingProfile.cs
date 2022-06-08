using AutoMapper;
using Hospital.Dtos;
using Hospital.Models;

namespace Hospital.AutoMapping
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Medcard, MedcardDto>().ReverseMap();
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<Questionnaire, QuestionnaireDto>()
                .ForMember(dest => dest.DoctorsName, opt => opt.MapFrom(src => src.Doctor.Name));
            CreateMap<Request, RequestDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
