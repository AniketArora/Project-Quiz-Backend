using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Resources {
    public class SubjectResource {
        public Guid Id { get; set; }

        public String SubjectName { get; set; }

        public String Description { get; set; }
    }
}
