using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class Questions {
        public Guid QuestionId { get; set; } = Guid.NewGuid();

        public String Question { get; set; }

        // NavigationProperties

        public QuizQuestion QuizQuestion { get; set; }
    }
}
