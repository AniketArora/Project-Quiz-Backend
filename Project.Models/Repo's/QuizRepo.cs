using Microsoft.EntityFrameworkCore;
using Project.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Repo_s {
    public class QuizRepo : GenericRepo<Quiz>, IQuizRepo {
        private readonly ProjectDbContext context;

        public QuizRepo(ProjectDbContext context) : base(context) {
            this.context = context;
        }

        public async Task<IEnumerable<Quiz>> GetQuizByDifficulityAsync(Quiz.DifficultyLevel level) {
            return await context.Quiz.Where(e => e.Difficulty == level).ToListAsync();
        }

        public async Task<IEnumerable<Quiz>> GetQuizbySubjectAsync(string subject) {
            return await context.Quiz
                .Include(e => e.QuizSubjects)
                .ThenInclude(e => e.Subject)
                .Where(e => e.QuizSubjects.Any(qs => qs.Subject.SubjectName == subject)).ToListAsync();
        }
    }
}
