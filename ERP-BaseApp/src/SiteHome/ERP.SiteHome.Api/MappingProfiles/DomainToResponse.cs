using AutoMapper;
using ERP.SiteHome.Core.Entity;
using ERP.SiteHome.Core.DTOs.Response;

namespace ERP.SiteHome.Api.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Department, GetDepartmentResponse>()
                 .ForMember(
                dest => dest.DepartmentId,
                opt => opt.MapFrom(src => src.Id));

            CreateMap<Batch, GetBatchResponse>()
                 .ForMember(
                dest => dest.BatchId,
                opt => opt.MapFrom(src => src.Id));

            CreateMap<Semester, GetSemesterResponse>()
                 .ForMember(
                dest => dest.SemesterId,
                opt => opt.MapFrom(src => src.Id));

        }
    }
}
