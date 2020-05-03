using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class QuestionAnswer {
        public Guid QuestionId { get; set; }

        public Guid AnswerId { get; set; }

        public bool IsCorrect { get; set; }
        public String Explination { get; set; }


        //NavigationProperties
        public Question Question { get; set; }

        public Answer Answer { get; set; }

    }
}
