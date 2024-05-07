using AutoMapper;
using ERP.Announcements.Core.DTOs.Response;
using ERP.Announcements.Core.Entity;

namespace ERP.Announcements.Api.MappingProfiles
{
    public class DomainToResponse : Profile
    {

        public DomainToResponse()
        {
            CreateMap<Announcement, GetAnnouncementResponse>();

            CreateMap<AnnouncementGroup, GetAnnouncementGroupResponse>()
                .ForMember(
                dest => dest.AnnouncementGroupId,
                opt => opt.MapFrom(src => src.Id))
                ;

            CreateMap<Student, GetStudentResponse>()
                .ForMember(
                dest => dest.StudentId,
                opt => opt.MapFrom(src => src.Id))
                ;

            CreateMap<Sender, GetSenderResponse>()
                .ForMember(
                dest => dest.SenderId,
                opt => opt.MapFrom(src => src.Id))
                ;
        }

    }
}
