using ERP.Announcements.Core.Entity;
using Microsoft.EntityFrameworkCore;



namespace ERP.Announcements.DataService.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Sender> Senders { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnouncementGroup> AnnouncementGroups { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.HasOne(g => g.AnnouncementGroup)
                      .WithMany(a => a.Announcements)
                      .HasForeignKey(g => g.AnnouncementGroupId)
                      .OnDelete(DeleteBehavior.NoAction)
                      .HasConstraintName("FK_Announcements_AnnouncementGroup");
            });


            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.HasOne(s => s.Sender)
                      .WithMany(a => a.Announcements)
                      .HasForeignKey(s => s.SenderId)
                      .OnDelete(DeleteBehavior.NoAction)
                      .HasConstraintName("FK_Announcements_Sender");
            });

            modelBuilder.Entity<AnnouncementGroup>(entity =>
            {
                entity.HasOne(s => s.Sender)
                      .WithMany(g => g.AnnouncementGroups)
                      .HasForeignKey(s => s.SenderId)
                      .OnDelete(DeleteBehavior.NoAction)
                      .HasConstraintName("FK_AnnouncementGroups_Sender");
            });

            modelBuilder.Entity<AnnouncementGroupStudent>()
                  .HasKey(ag => new { ag.AnnouncementGroupId, ag.StudentId });

            modelBuilder.Entity<AnnouncementGroupStudent>()
                .HasOne(ag => ag.AnnouncementGroup)
                .WithMany(ag => ag.AnnouncementGroupStudents)
                .HasForeignKey(ag => ag.AnnouncementGroupId);

            modelBuilder.Entity<AnnouncementGroupStudent>()
                .HasOne(ag => ag.Student)
                .WithMany(s => s.AnnouncementGroupStudents)
                .HasForeignKey(ag => ag.StudentId);

        }
    }
}
