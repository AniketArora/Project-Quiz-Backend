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
        
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public virtual DbSet<QuizQuestion> QuizQuestion { get; set; }
        public virtual DbSet<QuizSubject> QuizSubject { get; set; }
        public virtual DbSet<UserQuiz> UserQuiz { get; set; }
        public virtual DbSet<QuizAnswer> QuizAwnser { get; set; }

        //FLUENT API
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);
            //composite key 
            modelBuilder.Entity<QuizAnswer>(entity => {
                entity.HasKey(e => new { e.QuestionId, e.UserQuizId, e.AnswerId});
            });

            //modelBuilder.Entity<QuizAnswer>().HasOne(uq => uq.QuestionAnswer).WithMany(p => p.QuizAnswer).OnDelete(DeleteBehavior.Restrict);

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
