using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Resources {
    public class SubjectSaveResource {
        public Guid Id { get; set; }

        [Required]
        public String SubjectName { get; set; }

        public String Description { get; set; }
    }
}
