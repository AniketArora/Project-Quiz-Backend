using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;
using Project.Models.Repo_s;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.ViewModels {
    public class QuizQuestionAnswerVM {
        public Quiz Quiz { get; set; }

        public Collection<Question> Questions { get; set; }

        public MultiSelectList ListAnswers { get; set; }

        public string[] SelectedAnswersString { get; set; }

        public Guid UserQuizID { get; set; }

        public QuizQuestionAnswerVM() {
        }

        public QuizQuestionAnswerVM(IAnswerRepo AnswerRepo, Quiz quiz) {
            Quiz = quiz;
            this.Questions = new Collection<Question>();
            foreach (QuizQuestion qq in quiz.QuizQuestions) {
                Questions.Add(qq.Question);
            }

            var answers = new Collection<Answer>();

            foreach (Question q in this.Questions) {
                foreach (QuestionAnswer qa in q.QuestionAnswers) {
                    answers.Add(qa.Answer);
                }
            };

            this.ListAnswers = new MultiSelectList(answers, "Id", "Answertext");
        }
    }
}
