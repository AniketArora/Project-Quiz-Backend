using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.Models {
    public class Quiz {
        public Guid Id { get; set; }

        public String QuizName { get; set; }

        public enum DifficultyLevel {
            [Display(Name = "Easy")]
            Easy = 0,

            [Display(Name = "Medium")]
            Medium = 1,

            [Display(Name = "Hard")]
            Hard = 2
        }

        public DifficultyLevel Difficulty { get; set; }

        public String ThemeColor { get; set; }

        // NavigationProperties

        public ICollection<QuizSubject> QuizSubjects { get; set; }

        public ICollection<UserQuiz> UserQuizzes { get; set; }

        public ICollection<QuizQuestion> QuizQuestions { get; set; }

        public Quiz() {
            QuizSubjects = new Collection<QuizSubject>();
            UserQuizzes = new Collection<UserQuiz>();
            QuizQuestions = new Collection<QuizQuestion>();

        }
    }
}
