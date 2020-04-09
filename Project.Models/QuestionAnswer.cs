using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class QuestionAnswer {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid QuestionId { get; set; }

        public Guid AnswerId { get; set; }

        public bool IsCorrect { get; set; }

        //NavigationProperties
        public Questions Questions { get; set; }

        public Answers Answers { get; set; }

    }
}
