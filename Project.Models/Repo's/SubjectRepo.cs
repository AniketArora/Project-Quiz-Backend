using Project.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models.Repo_s {
    public class SubjectRepo : GenericRepo<Subject>, ISubjectRepo {
        private readonly ProjectDbContext _context;
        public SubjectRepo(ProjectDbContext context) : base(context) {
            this._context = context;
        }
    }
}
