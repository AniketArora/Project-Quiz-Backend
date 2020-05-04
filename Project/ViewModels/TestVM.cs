using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.ViewModels {
    public class TestVM {
        public Guid UserQuizId { get; set; }
        public List<Test2VM> Test2VMs { get; set; }

        public QuestionAnswerVM questionAnswerVM { get; set; }
    }
}
