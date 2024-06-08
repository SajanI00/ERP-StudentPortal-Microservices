using ERP.StudentRequests.Core.Entity;
using Microsoft.EntityFrameworkCore;


namespace ERP.StudentRequests.DataService.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // specifying the relationshp between entities

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasOne(s => s.Student)
                .WithMany(r => r.Requests)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Requests_Student");

            });


            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasOne(l => l.Lecturer)
                .WithMany(r => r.Requests)
                .HasForeignKey(l => l.LecturerId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Requests_Lecturer");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.HasOne(s => s.Student)
                .WithMany(r => r.Replies)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Replies_Student");

            });


            modelBuilder.Entity<Reply>(entity =>
            {
                entity.HasOne(l => l.Lecturer)
                .WithMany(r => r.Replies)
                .HasForeignKey(l => l.LecturerId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Replies_Lecturer");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.HasOne(l => l.Request)
                .WithMany(r => r.Replies)
                .HasForeignKey(l => l.RequestId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Replies_Request");
            });

        }
    }
}
