using Project.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models.Repo_s {
    public class QuizAnswerRepo : GenericRepo<QuizAnswer>, IQuizAnswerRepo {
        private readonly ProjectDbContext _context;

        public QuizAnswerRepo(ProjectDbContext context) : base(context) {
            this._context = context;
        }

        public void SaveBulk(IEnumerable<QuizAnswer> quizAnswers) {
            _context.AddRange(quizAnswers);
        }

    }
}
