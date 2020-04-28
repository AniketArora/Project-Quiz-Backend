using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class QuizAnswer {

        public Guid AnswerId { get; set; }

        public Guid QuestionId { get; set; }

        public Guid UserQuizId { get; set; }

        // NavigationProperties

        public Answer Answer { get; set; }

        public Question Question { get; set; }

        public UserQuiz UserQuiz { get; set; }
    }
}
