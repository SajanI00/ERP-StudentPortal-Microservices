using Microsoft.EntityFrameworkCore;
using ERP.StudentFeedback.Core.Entity;

namespace ERP.StudentFeedback.DataService
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FeedbackResponses> FeedbackResponses { get; set; }

        //     public DbSet<FeedbackGroup> FeedbackGroups { get; set; }
        //     public DbSet<FeedbackGroupStudent> FeedbackGroupStudents { get; set; }

        public DbSet<Module> Modules { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<LecturersModules> LecturersModules { get; set; }
        public DbSet<LecturersSemesters> LecturersSemesters { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            //modelBuilder.Entity<Feedback>(entity =>
            //{
            //    entity.HasOne(s => s.Student)
            //          .WithMany(a => a.Feedbacks)
            //          .HasForeignKey(s => s.StudentId)
            //          .OnDelete(DeleteBehavior.NoAction)
            //          .HasConstraintName("FK_Feedbacks_Student");
            //});

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasOne(s => s.Lecturer)
                      .WithMany(a => a.Feedbacks)
                      .HasForeignKey(s => s.LecturerId)
                      .OnDelete(DeleteBehavior.NoAction)
                      .HasConstraintName("FK_Feedbacks_Lecturer");
            });

            modelBuilder.Entity<FeedbackResponses>()
                  .HasKey(fg => new { fg.LecturerId, fg.ModuleId, fg.SemesterId });

            //modelBuilder.Entity<FeedbackGroup>(entity =>
            //{
            //    entity.HasOne(s => s.Lecturer)
            //          .WithMany(g => g.FeedbackGroups)
            //          .HasForeignKey(s => s.LecturerId)
            //          .OnDelete(DeleteBehavior.NoAction)
            //          .HasConstraintName("FK_FeedbackGroups_Lecturer");
            //});

            //modelBuilder.Entity<FeedbackGroupStudent>()
            //      .HasKey(fg => new { fg.FeedbackGroupId, fg.StudentId });

            //modelBuilder.Entity<FeedbackGroupStudent>()
            //    .HasOne(fg => fg.FeedbackGroup)
            //    .WithMany(fgs => fgs.FeedbackGroupStudents)
            //    .HasForeignKey(fg => fg.FeedbackGroupId);

            //modelBuilder.Entity<FeedbackGroupStudent>()
            //    .HasOne(fg => fg.Student)
            //    .WithMany(fgs => fgs.FeedbackGroupStudents)
            //    .HasForeignKey(fg => fg.StudentId);


            modelBuilder.Entity<LecturersModules>()
                 .HasKey(fg => new { fg.LecturerId, fg.ModuleId });

            modelBuilder.Entity<LecturersModules>()
                .HasOne(l => l.Lecturer)
                .WithMany(fgs => fgs.LecturersModules)
                .HasForeignKey(fg => fg.LecturerId);

            modelBuilder.Entity<LecturersModules>()
                .HasOne(fg => fg.Module)
                .WithMany(fgs => fgs.LecturersModules)
                .HasForeignKey(fg => fg.ModuleId);


            modelBuilder.Entity<LecturersSemesters>()
                .HasKey(fg => new { fg.LecturerId, fg.SemesterId });

            modelBuilder.Entity<LecturersSemesters>()
                .HasOne(fg => fg.Lecturer)
                .WithMany(fgs => fgs.LecturersSemesters)
                .HasForeignKey(fg => fg.LecturerId);

            modelBuilder.Entity<LecturersSemesters>()
                .HasOne(fg => fg.Semester)
                .WithMany(fgs => fgs.LecturersSemesters)
                .HasForeignKey(fg => fg.SemesterId);

        }


    }
}

