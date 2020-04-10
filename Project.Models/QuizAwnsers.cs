using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class QuizAwnsers {

        public Guid QuestionAnswerId { get; set; }

        public Guid UserQuizId { get; set; }

        // NavigationProperties
      

        public QuestionAnswer QuestionAnswer { get; set; }

        public UserQuiz UserQuiz { get; set; }
    }
}
