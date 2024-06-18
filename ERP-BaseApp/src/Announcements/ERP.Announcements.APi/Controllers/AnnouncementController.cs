using AutoMapper;
using ERP.Announcements.Api.Services.Publishers.Interfaces;
using ERP.Announcements.Core.Contracts;
using ERP.Announcements.Core.DTOs.Request;
using ERP.Announcements.Core.DTOs.Response;
using ERP.Announcements.Core.Entity;
using ERP.Announcements.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Announcements.Api.Controllers
{
    public class AnnouncementController : BaseController
    {
        public readonly IAnnouncementNotificationPublisherService _announcementService;
        private static readonly Guid FixedStudentId = new Guid("348d1f7f-4687-4eae-bb4b-11b43286d3dc");

        public AnnouncementController(IUnitOfWork unitOfWork, IMapper mapper, IAnnouncementNotificationPublisherService announcementService) 
            : base(unitOfWork, mapper)
        {
            _announcementService = announcementService;
        }

        [HttpGet]
        [Route("Students/{studentId:guid}")]
        public async Task<IActionResult> GetStudentAnnouncements(Guid studentId)
        {

            var announcements = await _unitOfWork.Announcements.GetStudentAnnouncementAsync(studentId);

            if (announcements == null || !announcements.Any())
                return NotFound("Announcements not found");

            var result = _mapper.Map<IEnumerable<GetAnnouncementResponse>>(announcements);

            return Ok(result);


        }

        // Get announcements for One student
        [HttpGet]
        [Route("Students/Announcement")]
        public async Task<IActionResult> GetOneStudentAnnouncements()
        {

            var announcements = await _unitOfWork.Announcements.GetStudentAnnouncementAsync(FixedStudentId);

            if (announcements == null || !announcements.Any())
                return NotFound("Announcements not found");

            var result = _mapper.Map<IEnumerable<GetAnnouncementResponse>>(announcements);

            return Ok(result);


        }

        [HttpGet]
        [Route("Senders/{senderId:guid}")]
        public async Task<IActionResult> GetSenderAnnouncements(Guid senderId)
        {
            var announcements = await _unitOfWork.Announcements.GetSenderAnnouncementAsync(senderId);

            if (announcements == null || !announcements.Any())
                return NotFound("Announcements not found");

            var result = _mapper.Map<IEnumerable<GetAnnouncementResponse>>(announcements);

            return Ok(result);

        }

        [HttpGet]
        [Route("AnnouncementGroups/{announcementGroupId:guid}")]
        public async Task<IActionResult> GetAnnouncementGroupAnnouncements(Guid announcementGroupId)
        {
            var announcements = await _unitOfWork.Announcements.GetAnnouncementGroupAnnouncementAsync(announcementGroupId);

            if (announcements == null || !announcements.Any())
                return NotFound("Announcements not found");

            var result = _mapper.Map<IEnumerable<GetAnnouncementResponse>>(announcements);

            return Ok(result);

        }

        [HttpPost("")]
        public async Task<IActionResult> AddAnnouncement([FromBody] CreateAnnouncementRequest announcement)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var announcementGroup = await _unitOfWork.AnnouncementGroups.GetById(announcement.AnnouncementGroupId);
            if (announcementGroup == null)
            {
                return NotFound($"AnnouncementGroup with ID {announcement.AnnouncementGroupId} not found.");
            }

            announcement.AnnouncementGroupName = announcementGroup.GroupName;

            var sender = await _unitOfWork.Senders.GetById(announcement.SenderId);
            if (sender == null)
            {
                return NotFound($"Sender with ID {announcement.SenderId} not found.");
            }

            announcement.SenderName = sender.Name;

            var result = _mapper.Map<Announcement>(announcement);

            await _unitOfWork.Announcements.Add(result);
            await _unitOfWork.CompleteAsync();

            AnnouncementCreatedNotificationRecord announcementRecord = new AnnouncementCreatedNotificationRecord
              (AnnouncementId: result.Id,
               Text: result.Text,
               AddedDate: result.AddedDate,
               StudentGroupName: result.AnnouncementGroupName,
               SenderName: result.SenderName
              );

            await _announcementService.SendNotification(announcementRecord);

            return CreatedAtAction(nameof(GetAnnouncementGroupAnnouncements), new { announcementGroupId = result.AnnouncementGroupId }, result);

        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateAnnouncement([FromBody] UpdateAnnouncementRequest announcement)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Announcement>(announcement);

            await _unitOfWork.Announcements.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
