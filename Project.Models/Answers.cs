using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class Answers {
        public Guid AnswerId { get; set; }

        public String Answer { get; set; }

        public String Explination { get; set; }

        //NavigationProperties

        public QuestionAnswer QuestionAnswer { get; set; }

        public QuizAwnsers QuizAwnsers { get; set; }
    }
}
