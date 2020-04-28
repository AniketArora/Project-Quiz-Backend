using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Resources {
    public class QuestionSaveResource {
        public Guid Id { get; set; }

        [Required]
        public String Questiontext { get; set; }

        public int Score { get; set; }
    }
}
