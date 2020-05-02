using Microsoft.EntityFrameworkCore;
using Project.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Repo_s {
    public class QuizRepo : GenericRepo<Quiz>, IQuizRepo {
        private readonly ProjectDbContext _context;

        public QuizRepo(ProjectDbContext context) : base(context) {
            this._context = context;
        }

        public override async Task<IEnumerable<Quiz>> GetAllAsync() {
            return await _context.Quiz
                .Include(q => q.QuizSubjects).ThenInclude(q => q.Subject)
                .Include(q => q.QuizQuestions).ThenInclude(qq => qq.Question).ThenInclude(q => q.QuizAwnsers).ThenInclude(qa => qa.Answer)
                .ToListAsync();
        }
        public override async Task<Quiz> GetAsync(Guid id) {
            return await _context.Quiz.Include(q => q.QuizSubjects).ThenInclude(q => q.Subject).SingleOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<Quiz>> GetQuizByDifficulityAsync(Quiz.DifficultyLevel level) {
            return await _context.Quiz.Where(e => e.Difficulty == level).ToListAsync();
        }

        public async Task<IEnumerable<Quiz>> GetQuizbySubjectAsync(string subject) {
            return await _context.Quiz
                .Include(e => e.QuizSubjects)
                .ThenInclude(e => e.Subject)
                .Where(e => e.QuizSubjects.Any(qs => qs.Subject.SubjectName == subject)).ToListAsync();
        }
    }
}
