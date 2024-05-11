using ERP.Messaging.Core.Student;
using ERP.StudentRequests.Core.Interfaces;
using MassTransit;
using ERP.StudentRequests.Core.Entity;

namespace ERP.StudentRequests.Api.Services.Consumers
{
    public class ReqStudentNotificationConsumer : IConsumer<StudentCreatedNotificationRecord>
    {
        private readonly ILogger<ReqStudentNotificationConsumer> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ReqStudentNotificationConsumer(ILogger<ReqStudentNotificationConsumer> logger, IUnitOfWork unitOfWork)
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
                    RegNo = studentNotification.RegistrationNumber
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
