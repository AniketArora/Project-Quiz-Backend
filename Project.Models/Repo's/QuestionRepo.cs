using Microsoft.EntityFrameworkCore;
using Project.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Repo_s {
    public class QuestionRepo : GenericRepo<Question>, IQuestionRepo {
        private readonly ProjectDbContext _context;
        public QuestionRepo(ProjectDbContext context) : base(context) {
            this._context = context;
        }

        public override async Task<IEnumerable<Question>> GetAllAsync() {
            return await _context.Question
                .Include(q => q.QuestionAnswers).ThenInclude(qa => qa.Answer)
                .ToListAsync();
        }

        public override async Task<Question> GetAsync(Guid id) {
            return await _context.Question
                .Include(qa => qa.QuestionAnswers).ThenInclude(a => a.Answer)
                .SingleOrDefaultAsync(q => q.Id == id);
        }
    }
}
