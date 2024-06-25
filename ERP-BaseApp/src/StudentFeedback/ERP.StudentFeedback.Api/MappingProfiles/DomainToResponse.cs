using AutoMapper;
using ERP.StudentFeedback.Core.DTOs.Response;
using ERP.StudentFeedback.Core.Entity;

namespace ERP.StudentFeedback.Api.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Feedback, GetFeedbackResponse>()
                .ForMember(
                dest => dest.FeedbackId,
                opt => opt.MapFrom(src => src.Id));

            CreateMap<Student, GetStudentResponse>()
                .ForMember(
                dest => dest.StudentId,
                opt => opt.MapFrom(src => src.Id));


            CreateMap<Lecturer, GetLecturerResponse>()
                .ForMember(
                dest => dest.LecturerId,
                opt => opt.MapFrom(src => src.Id));

            CreateMap<Module, GetModuleResponse>()
                .ForMember(
                dest => dest.ModuleId,
                opt => opt.MapFrom(src => src.Id));

            CreateMap<Semester, GetSemesterResponse>()
                .ForMember(
                dest => dest.SemesterId,
                opt => opt.MapFrom(src => src.Id));

            CreateMap<LecturersModules, GetLecturersModulesResponse>()
                .ForMember(
                dest => dest.LecturersModulesId,
                opt => opt.MapFrom(src => src.Id));

            CreateMap<LecturersSemesters, GetLecturersSemestersResponse>()
                .ForMember(
                dest => dest.LecturersSemestersId,
                opt => opt.MapFrom(src => src.Id));
        }
    }
}
