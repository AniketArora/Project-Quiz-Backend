using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class UserQuiz {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        public Guid QuizId { get; set; }

        public int Score { get; set; }

        //NavigationProperties

        public Users Users { get; set; }

        public Quizzes Quizzes { get; set; }
    }
}
