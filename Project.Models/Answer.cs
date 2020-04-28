using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class Answer {
        public Guid Id { get; set; }

        public String Answertext { get; set; }

        public String Explination { get; set; }

        //NavigationProperties

        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }

        public ICollection<QuizAnswer> QuizAwnsers { get; set; }

        public ICollection<UserQuiz> UserQuizzes { get; set; }

    }
}
