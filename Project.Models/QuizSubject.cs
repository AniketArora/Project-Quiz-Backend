using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class QuizSubject {
       

        public Guid QuizId { get; set; }

        public Guid SubjectId { get; set; }

        // NavigationProperties
        public Subject Subject { get; set; }

        public Quiz Quiz { get; set; }
    }
}
