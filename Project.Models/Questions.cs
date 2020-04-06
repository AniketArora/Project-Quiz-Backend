using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class Questions {
        public Guid QuestionId { get; set; }

        public String Question { get; set; }

        public Guid SubjectId { get; set; }

        public bool Correct { get; set; }


        // NavigationProperties
        public virtual ICollection<UserQuestions> UserQuestions { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
