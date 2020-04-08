using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class Subjects {
        public Guid SubjectId { get; set; } = Guid.NewGuid();

        public String SubjectName { get; set; }

        public String Description { get; set; }

        // NavigationProperties
        public QuizSubject QuizSubject { get; set; }
    }
}
