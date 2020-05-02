using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Resources {
    public class AnswerQuizSaveResource {
        public Guid AnswerId { get; set; }

        public bool IsCorrect { get; set; }

        
    }
}
