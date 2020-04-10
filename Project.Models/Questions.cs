using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class Questions {
        public Guid Id { get; set; } = Guid.NewGuid();

        public String Question { get; set; }

        public int Score { get; set; }

        // NavigationProperties

        public ICollection<QuizQuestion> QuizQuestion { get; set; }

        public ICollection<QuizAwnsers> QuizAwnsers { get; set; }
    }
}
