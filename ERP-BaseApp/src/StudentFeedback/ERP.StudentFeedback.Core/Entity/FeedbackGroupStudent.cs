

namespace ERP.StudentFeedback.Core.Entity
{
    public class FeedbackGroupStudent : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid AnnouncementGroupId { get; set; }
        public FeedbackGroup FeedbackGroup { get; set; }
    }
}
