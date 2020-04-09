using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class QuizQuestion {

        public Guid QuizId { get; set; }

        public Guid QuestionId { get; set; }

        // NavigationProperties

        public Quizzes Quizzes { get; set; }

        public Questions Questions { get; set; }
    }
}
