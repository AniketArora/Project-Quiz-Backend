using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Resources {
    public class QuestionResource {
        public Guid Id { get; set; }

        public String Questiontext { get; set; }

        public int Score { get; set; }

        public IEnumerable<AnswerResource> Answers { get; set; }
    }
}
