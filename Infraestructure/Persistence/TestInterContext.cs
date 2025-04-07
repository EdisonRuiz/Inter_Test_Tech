using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
    public partial class TestInterContext : DbContext
    {
        public TestInterContext(DbContextOptions<TestInterContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<UserSubject> UserSubjects { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);                
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength();
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsFixedLength();
                entity.Property(e => e.EnrollmentDate);
                entity.Property(e => e.IdRole);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsFixedLength();
                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<UserSubject>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn();
                entity.HasOne(e => e.User).WithMany(p => p.UserSubjects)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSubjects_Users");
                entity.HasOne(e => e.Subject).WithMany(p => p.UserSubjects)
                    .HasForeignKey(d => d.IdSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSubjects_Subjects");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
