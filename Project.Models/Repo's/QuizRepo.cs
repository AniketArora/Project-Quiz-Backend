using Microsoft.EntityFrameworkCore;
using Project.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Repo_s {
    public class QuizRepo {
        private readonly ProjectDbContext context;

        public QuizRepo(ProjectDbContext context) {
            this.context = context;
        }

        public async Task<IEnumerable<Quiz>> GetAllQuizzesAsync() {
            return await context.Quiz.ToListAsync();
        }

        public async Task<Quiz> GetQuizByIdAsync(Guid id) {
            return await context.Quiz.SingleOrDefaultAsync<Quiz>(e => e.Id == id);
        }

        public async Task<Quiz> GetQuizByDifficulityAsync(Quiz.DifficultyLevel level) {
            return await context.Quiz.SingleOrDefaultAsync<Quiz>(e => e.Difficulty == level);
        }

        public async Task<Quiz> GetQuizbySubjectAsync(string subject) {
            //return await context.Quiz
            //    .Include(e => e.quiz)
            //    .
            return null;
        }
    }
}
