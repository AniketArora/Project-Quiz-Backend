using Microsoft.EntityFrameworkCore;
using Project.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Repo_s {
    public class AnswerRepo : GenericRepo<Answer>, IAnswerRepo {
        private readonly ProjectDbContext _context;
        public AnswerRepo(ProjectDbContext context) : base(context) {
            this._context = context;
        }

        public async Task<ICollection<Answer>> getByQuestionId(Guid id) {
            return await _context.Answer.Include(a => a.QuestionAnswers)
                .ThenInclude(qa => qa.Question)
                .Where(e => e.QuestionAnswers
                .Any(qa => qa.Answer.Id == id)).ToListAsync();
        }
    }
}
