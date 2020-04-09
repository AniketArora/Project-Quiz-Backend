using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class QuizAwnsers {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        public Guid QuizId { get; set; }

        public Guid AnswerId { get; set; }

        public Guid QuestionId { get; set; }

        // NavigationProperties
        public Users Users { get; set; }

        public Quizzes Quizzes { get; set; }

        public Answers Answers { get; set; }

        public Questions Questions { get; set; }
    }
}
