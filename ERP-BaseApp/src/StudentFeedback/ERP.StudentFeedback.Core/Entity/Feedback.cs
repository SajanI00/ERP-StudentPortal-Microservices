

namespace ERP.StudentFeedback.Core.Entity
{
    public class Feedback : BaseEntity
    {

        public Feedback() { }
        public string ModuleName { get; set; } = string.Empty;
        public string SelectedLecturer { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string OverallFeedback { get; set; } = string.Empty;

        public int LectureContentRating { get; set; }
        public int LectureEngagementRating { get; set; }
        public int CommunicationRating { get; set; }
        public int ExamplesRating { get; set; }
        public int CoverageRating { get; set; }
        public int PaceRating { get; set; }
        public int ParticipationRating { get; set; }
        public int VisualAidsRating { get; set; }
        public int RealWorldApplicationsRating { get; set; }
        public int ConceptRating { get; set; }
        public int LectureOrganizationRating { get; set; }
        public int InteractionRating { get; set; }
        public int ExplanationClarityRating { get; set; }
        public int SummaryEffectivenessRating { get; set; }
        public int RelevanceToCourseRating { get; set; }


        public List<int> Ratings = new List<int>(new int[15]);

        public List<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
        public List<string> Semesters { get; set; } = new List<string>();
        public List<string> Modules { get; set; } = new List<string>();
    }
}
