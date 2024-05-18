using ERP.Messaging.Core.Student;
using MassTransit;
using ERP.Announcements.Core.Entity;
using ERP.Announcements.Core.Interfaces;

namespace ERP.Announcements.Api.Services.Consumers
{
    public class AnnouncementStudentNotificationConsumer : IConsumer<StudentCreatedNotificationRecord>
    {
        private readonly ILogger<AnnouncementStudentNotificationConsumer> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public AnnouncementStudentNotificationConsumer(ILogger<AnnouncementStudentNotificationConsumer> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<StudentCreatedNotificationRecord> context)
        {
            try
            {
                var studentNotification = context.Message;

                var newStudent = new Student
                {
                    Id = studentNotification.StudentId,
                    RegNo = studentNotification.RegistrationNumber,
                    Name = studentNotification.StudentFullName,
                    Status = studentNotification.Status,
                    AddedDate = studentNotification.AddedDate
                };

                _unitOfWork.Students.Add(newStudent);
                await _unitOfWork.CompleteAsync();

                _logger.LogInformation($"Added student to the Students table: {studentNotification.StudentId}");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing student creation notification.");
                throw;
            }

        }
    }
}
