
namespace ERP.StudentRequests.Core.Contracts
{
    public record RequestCreatedNotificationRecord
  (
        Guid RequestId, 
        string Topic, 
        DateTime AddedDate,
        string StudentName,
        string LecturerName
  );

}
