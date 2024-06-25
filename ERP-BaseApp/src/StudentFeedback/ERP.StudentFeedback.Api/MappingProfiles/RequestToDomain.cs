using AutoMapper;
using ERP.StudentFeedback.Core.DTOs.Request;
using ERP.StudentFeedback.Core.Entity;

namespace ERP.StudentFeedback.Api.MappingProfiles
{
    public class RequestToDomain : Profile
    {

        public RequestToDomain()
        {

            CreateMap<CreateFeedbackRequest, Feedback>()
                .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => 1))
                .ForMember(
                dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow));



            //CreateMap<CreateAnnouncementGroupRequest, AnnouncementGroup>()
            //    .ForMember(
            //    dest => dest.Status,
            //    opt => opt.MapFrom(src => 1))
            //    .ForMember(
            //    dest => dest.AddedDate,
            //    opt => opt.MapFrom(src => DateTime.UtcNow))
            //    .ForMember(
            //    dest => dest.UpdatedDate,
            //    opt => opt.MapFrom(src => DateTime.UtcNow))
            //;


            CreateMap<CreateStudentRequest, Student>()
                 .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => 1))
                .ForMember(
                dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;

            CreateMap<CreateLecturerRequest, Lecturer>()
               .ForMember(
              dest => dest.Status,
              opt => opt.MapFrom(src => 1))
              .ForMember(
              dest => dest.AddedDate,
              opt => opt.MapFrom(src => DateTime.UtcNow))
              .ForMember(
              dest => dest.UpdatedDate,
              opt => opt.MapFrom(src => DateTime.UtcNow));


            CreateMap<CreateModuleRequest, Module>()
            .ForMember(
            dest => dest.Status,
            opt => opt.MapFrom(src => 1))
            .ForMember(
            dest => dest.AddedDate,
            opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(
            dest => dest.UpdatedDate,
            opt => opt.MapFrom(src => DateTime.UtcNow));
            
            CreateMap<CreateSemesterRequest, Semester>()
            .ForMember(
            dest => dest.Status,
            opt => opt.MapFrom(src => 1))
            .ForMember(
            dest => dest.AddedDate,
            opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(
            dest => dest.UpdatedDate,
            opt => opt.MapFrom(src => DateTime.UtcNow));


            CreateMap<CreateLecturersModulesRequest, LecturersModules>()
            .ForMember(
            dest => dest.Status,
            opt => opt.MapFrom(src => 1))
            .ForMember(
            dest => dest.AddedDate,
            opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(
            dest => dest.UpdatedDate,
            opt => opt.MapFrom(src => DateTime.UtcNow));


            CreateMap<CreateLecturersSemestersRequest, LecturersSemesters>()
            .ForMember(
            dest => dest.Status,
            opt => opt.MapFrom(src => 1))
            .ForMember(
            dest => dest.AddedDate,
            opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(
            dest => dest.UpdatedDate,
            opt => opt.MapFrom(src => DateTime.UtcNow));


        }

    }
}
