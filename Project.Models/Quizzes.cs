using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class Quizzes {
        public Guid QuizId { get; set; } = Guid.NewGuid();

        public String QuizName { get; set; }

        public enum DifficultyLevel {
            Easy = 0,
            Medium = 1,
            Hard = 2
        }

        public DifficultyLevel Difficulty { get; set; }

        public String ThemeColor { get; set; }

        // NavigationProperties

        public QuizSubject Subject { get; set; }

        public QuizAwnsers QuizAwnsers { get; set; }
    }
}
