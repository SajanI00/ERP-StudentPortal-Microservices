using AutoMapper;
using ERP.SiteHome.Core.Entity;
using ERP.SiteHome.Core.DTOs.Request;

namespace ERP.SiteHome.Api.MappingProfiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {

            CreateMap<CreateDepartmentRequest, Department>()
                .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => 1))
                .ForMember(
                dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<CreateBatchRequest, Batch>()
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

        }
    }
}
