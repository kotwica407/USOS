using Microsoft.EntityFrameworkCore;
using System;
using USOSData.Models;

namespace USOSData
{
    public class USOSContext : DbContext
    {
        public USOSContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Semester_Student> Semester_Students { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Student_Activity> Student_Activities { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Semester_Student>().HasKey(p => new { p.SemesterId, p.StudentId });
            modelBuilder.Entity<Student_Activity>().HasKey(p => new { p.StudentId, p.ActivityId });
            modelBuilder.Entity<Student>().HasMany(p => p.Semester_Students).WithOne().HasForeignKey(p => p.StudentId);
            modelBuilder.Entity<Semester>().HasMany(p => p.Semester_Students).WithOne().HasForeignKey(p => p.SemesterId);
            modelBuilder.Entity<Student>().HasMany(p => p.Student_Activities).WithOne().HasForeignKey(p => p.StudentId);
            modelBuilder.Entity<Activity>().HasMany(p => p.Student_Activities).WithOne().HasForeignKey(p => p.ActivityId);
        }
    }
}
