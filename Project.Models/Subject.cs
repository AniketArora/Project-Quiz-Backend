using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class Subject {
        public Guid SubjectId { get; set; }

        public String SubjectName { get; set; }

        public String Description { get; set; }

        public virtual Questions Questions { get; set; }
    }
}
