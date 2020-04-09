using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class QuizSubject {
       

        public Guid QuizId { get; set; }

        public Guid SubjectId { get; set; }

        // NavigationProperties
        public Subjects Subjects { get; set; }

        public Quizzes Quizzes { get; set; }
    }
}
