using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class Quiz {
        public Guid Id { get; set; }

        public String QuizName { get; set; }

        public enum DifficultyLevel {
            Easy = 0,
            Medium = 1,
            Hard = 2
        }

        public DifficultyLevel Difficulty { get; set; }

        public String ThemeColor { get; set; }

        // NavigationProperties

        public ICollection<QuizSubject> Subjects { get; set; }

        public ICollection<UserQuiz> UserQuizzes { get; set; }
    }
}
