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
            CreateMap<Question, QuestionDto>().ForMember(dest => dest.QuestionnaireId, opt => opt.MapFrom(src => src.QuestionnaireId)).ReverseMap();
            //CreateMap<Question, QuestionDto>();
            CreateMap<Questionnaire, QuestionnaireDto>()
                .ForMember(dest => dest.DoctorsName, opt => opt.MapFrom(src => src.Doctor.Name))
                .ForMember(dest => dest.DoctorsSpec, opt => opt.MapFrom(src => src.Doctor.Spec));
            CreateMap<Request, RequestDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
