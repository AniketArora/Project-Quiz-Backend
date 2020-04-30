using Project.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models.Repo_s {
    public class AnswerRepo : GenericRepo<Answer>, IAnswerRepo {
        private readonly ProjectDbContext _context;
        public AnswerRepo(ProjectDbContext context) : base(context) {
            this._context = context;
        }
    }
}
