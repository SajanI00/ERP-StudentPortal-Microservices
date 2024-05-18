

namespace ERP.Announcements.Core.Contracts
{
    public record AnnouncementCreatedNotificationRecord
 (
       Guid AnnouncementId,
       string Text,
       DateTime AddedDate,
       string StudentGroupName,
       string SenderName
 );
}
