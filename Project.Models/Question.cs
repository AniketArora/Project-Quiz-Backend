using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class Question {
        public Guid Id { get; set; } = Guid.NewGuid();

        public String Questiontext { get; set; }

        public int Score { get; set; }

        // NavigationProperties

        public ICollection<QuizQuestion> QuizQuestions { get; set; }

        public ICollection<QuizAnswer> QuizAwnsers { get; set; }
    }
}
