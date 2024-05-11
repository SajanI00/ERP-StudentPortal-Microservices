using AutoMapper;
using ERP.StudentRequests.Core.DTOs.Response;
using ERP.StudentRequests.Core.Entity;

namespace ERP.StudentRequests.Api.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Request, GetReqLetterResponse>();

            CreateMap<Student, GetStudentResponse>()
                .ForMember(
                dest => dest.StudentId,
                opt => opt.MapFrom(src => src.Id));


            CreateMap<Lecturer, GetLecturerResponse>()
                .ForMember(
                dest => dest.LecturerId,
                opt => opt.MapFrom(src => src.Id));
        }
    }
}
