using Microsoft.EntityFrameworkCore;
using ERP.SiteHome.Core.Entity;

namespace ERP.SiteHome.DataService
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // specifying the relationshp between entities

            modelBuilder.Entity<Batch>(entity =>
            {
                entity.HasOne(s => s.Department)
                .WithMany(r => r.Batches)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Batches_Department");

            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasOne(s => s.Batch)
                .WithMany(r => r.Semesters)
                .HasForeignKey(s => s.BatchId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Semester_Batch");

            });


        }
    }
}
