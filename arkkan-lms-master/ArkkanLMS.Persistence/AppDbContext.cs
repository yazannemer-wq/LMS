using ArkkanLMS.Core.Entities;
using ArkkanLMS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArkkanLMS.Persistence
{
    public partial class AppDbContext : DbContext, IAppDbContext
    {
        private readonly IConfiguration configuration;

        public DbSet<AuthorCourseLesson> AuthorCourseLessons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ClassSession> ClassSessions { get; set; }
        public DbSet<CourseBooking> CourseBookings { get; set; }
        public DbSet<RolePermissionAssignment> RolePermissionAssignments { get; set; }

        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO Define indexes 

            #region Many to Manys
            modelBuilder.Entity<AuthorCourseLesson>()
                .HasKey(p => new { p.AuthorId, p.CourseLessonId });

            modelBuilder.Entity<AuthorCourseLesson>()
                .HasOne(p => p.Author)
                .WithMany(p => p.CourseLessons)
                .HasForeignKey(p => p.AuthorId);
            
            modelBuilder.Entity<AuthorCourseLesson>()
                .HasOne(p => p.CourseLesson)
                .WithMany(p => p.Authors)
                .HasForeignKey(p => p.CourseLessonId);
            #endregion

            #region Soft Deletes
            // TODO Investigate using IAuditableEntity
            modelBuilder.Entity<Course>().HasQueryFilter(e => e.DateDeleted == null);
            modelBuilder.Entity<CourseLesson>().HasQueryFilter(e => e.DateDeleted == null);
            modelBuilder.Entity<CourseLessonAttachment>().HasQueryFilter(e => e.DateDeleted == null);
            modelBuilder.Entity<Author>().HasQueryFilter(e => e.DateDeleted == null);
            modelBuilder.Entity<User>().HasQueryFilter(e => e.DateDeleted == null);
            modelBuilder.Entity<ClassSession>().HasQueryFilter(e => e.DateDeleted == null);
            modelBuilder.Entity<CourseBooking>().HasQueryFilter(e => e.DateDeleted == null);
            modelBuilder.Entity<RolePermissionAssignment>().HasQueryFilter(e => e.DateDeleted == null);
            #endregion

            modelBuilder.Entity<User>().HasIndex(e => e.Email).IsUnique();
            modelBuilder.Entity<RolePermissionAssignment>().HasIndex(e => new { e.Role, e.Permission }).IsUnique();
        }

        public override int SaveChanges()
        {
            HandleIAuditableEntities();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            HandleIAuditableEntities();

            return await base.SaveChangesAsync(cancellationToken);
        }

        private void HandleIAuditableEntities()
        {
            var entities = ChangeTracker.Entries().Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));

            foreach (var entity in entities)
            {
                if (typeof(IAuditableEntity).IsAssignableFrom(entity.Entity.GetType()))
                {
                    var dateModified = DateTime.UtcNow;

                    if (entity.State == EntityState.Added)
                    {
                        entity.CurrentValues["DateCreated"] = dateModified;
                    }

                    if (entity.State == EntityState.Deleted)
                    {
                        entity.State = EntityState.Modified;
                        entity.CurrentValues["DateDeleted"] = dateModified;
                    }

                    entity.CurrentValues["DateUpdated"] = dateModified;
                }
            }
        }
    }
}


