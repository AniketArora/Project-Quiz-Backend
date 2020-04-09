using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class Answers {
        public Guid Id { get; set; }

        public String Answer { get; set; }

        public String Explination { get; set; }

        //NavigationProperties

        public ICollection<QuestionAnswer> QuestionAnswer { get; set; }

        public ICollection<QuizAwnsers> QuizAwnsers { get; set; }
    }
}
