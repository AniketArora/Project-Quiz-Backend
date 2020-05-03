using Project.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Repo_s {
    public class UserQuizRepo : GenericRepo<UserQuiz>, IUserQuizRepo {
        private readonly ProjectDbContext _context;
        public UserQuizRepo(ProjectDbContext context) : base(context) {
            this._context = context;
        }

        //public async Task<UserQuiz> getByQuizIdAndUserId(Guid QuizId, string UserId) {
        //    return await _context.UserQuiz.Where(e => e.QuizId == QuizId).Where(e => e.UserId == UserId).FirstOrDefault();
        //}
    }
}
