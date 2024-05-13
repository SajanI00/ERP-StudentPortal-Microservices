

namespace ERP.Messaging.Core.Student
{
    public record StudentCreatedNotificationRecord
    (
        Guid StudentId,
        string StudentFullName,
        string RegistrationNumber,
        int Status,
        DateTime AddedDate,
        DateTime DateOfBirth  
     );
}
