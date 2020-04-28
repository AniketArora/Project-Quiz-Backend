using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class Subject {
        public Guid Id { get; set; } 

        public String SubjectName { get; set; }

        public String Description { get; set; }

        // NavigationProperties
        public ICollection<QuizSubject> QuizSubjects { get; set; }
    }
}
