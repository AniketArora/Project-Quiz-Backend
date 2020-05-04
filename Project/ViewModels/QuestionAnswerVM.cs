using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;
using Project.Models.Repo_s;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.ViewModels {
    public class QuestionAnswerVM {
        public Question question { get; set; }

        public MultiSelectList ListAnswers { get; set; }

        public string[] SelectedAnswersString { get; set; }

        public TestVM TestVM { get; set; }

        public Test2VM Test2VM { get; set; }

        public QuestionAnswerVM() {

        }

        public QuestionAnswerVM(Question question) {
            var answers = new Collection<Answer>();
            this.question = question;
            foreach (QuestionAnswer qa in question.QuestionAnswers) {
                answers.Add(qa.Answer);
            }
            this.ListAnswers = new MultiSelectList(answers, "Id", "Answertext");
        }
    }
}
