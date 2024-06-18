using AutoMapper;
using ERP.StudentRequests.Core.DTOs.Request;
using ERP.StudentRequests.Core.Entity;

namespace ERP.StudentRequests.Api.MappingProfiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<CreateReqLetterRequest, Request>()
                .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => 1))
                .ForMember(
                dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow));




            CreateMap<UpdateReqLetterRequest, Request>()
                .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;

            CreateMap<CreateReplyRequest, Reply>()
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

            CreateMap<UpdateStudentRequest, Student>()
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
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;

            CreateMap<UpdateLecturerRequest, Lecturer>()
                .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            ;
        }
    }
}
