using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Models.Data {
    public class ProjectDbContext : IdentityDbContext<IdentityUser> {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options) {
        }
        
        public virtual DbSet<Answers> Answers { get; set; }

        public virtual DbSet<QuestionAnswer> QuestionAnswers { get; set; }

        public virtual DbSet<Questions> Questions { get; set; }

        public virtual DbSet<QuizAwnsers> QuizAwnsers { get; set; }

        public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }

        public virtual DbSet<QuizSubject> QuizSubjects { get; set; }

        public virtual DbSet<Quizzes> Quizzes { get; set; }

        public virtual DbSet<Subjects> Subjects { get; set; }

        public virtual DbSet<UserQuiz> UserQuizzes { get; set; }

        //public virtual DbSet<Users> Users { get; set; }

        //FLUENT API
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);
            //composite key 
            modelBuilder.Entity<QuizAwnsers>(entity => {
                entity.HasKey(e => new { e.QuestionAnswerId, e.UserQuizId });
            });

            modelBuilder.Entity<QuestionAnswer>(entity => {
                entity.HasKey(e => new { e.AnswerId, e.QuestionId });
            });

            modelBuilder.Entity<QuizQuestion>(entity => {
                entity.HasKey(e => new { e.QuestionId, e.QuizId });
            });

            modelBuilder.Entity<QuizSubject>(entity => {
                entity.HasKey(e => new { e.QuizId, e.SubjectId });
            });
        } 
 
    }
}
