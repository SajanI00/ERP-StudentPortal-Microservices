

namespace ERP.StudentFeedback.Core.DTOs.Request
{
    public class CreateFeedbackRequest
    {

    //    public Guid StudentId { get; set; }
        public Guid LecturerId { get; set; }
        public Guid SemesterId { get; set; }
        public Guid ModuleId { get; set; }

        public string ModuleName { get; set; } = string.Empty;
        public string LecturerName { get; set; } = string.Empty;
        public string SemesterName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string OverallFeedback { get; set; } = string.Empty;

        public int LectureContentRating { get; set; }        // 0
        public int LectureEngagementRating { get; set; }     // 1
        public int CommunicationRating { get; set; }         // 2
        public int ExamplesRating { get; set; }              // 3
        public int CoverageRating { get; set; }              // 4
        public int PaceRating { get; set; }                  // 5
        public int ParticipationRating { get; set; }         // 6
        public int VisualAidsRating { get; set; }            // 7
        public int RealWorldApplicationsRating { get; set; } // 8
        public int ConceptRating { get; set; }               // 9
        public int LectureOrganizationRating { get; set; }   // 10
        public int InteractionRating { get; set; }           // 11
        public int ExplanationClarityRating { get; set; }    // 12
        public int SummaryEffectivenessRating { get; set; }  // 13
        public int RelevanceToCourseRating { get; set; }     // 14
    }
}
