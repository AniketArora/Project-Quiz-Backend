using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class Awnsers {

        public Guid AwnserId { get; set; }

        public String Awnser { get; set; }

        public bool Correct { get; set; }

        // NavigationProperties

        public virtual UserQuestions UserQuestions { get; set; }
    }
}
