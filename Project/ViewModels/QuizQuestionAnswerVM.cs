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

        public Guid UserQuizID { get; set; }

        public Collection<QuestionAnswerVM> QuestionAnswerVMs{ get; set; }

        public string[] SelectedAnswersString { get; set; }

        public TestVM TestVM { get; set; }

        public QuizQuestionAnswerVM() {
        }

        public QuizQuestionAnswerVM(IAnswerRepo AnswerRepo, Quiz quiz) {
            Quiz = quiz;
            this.Questions = new Collection<Question>();
            this.QuestionAnswerVMs = new Collection<QuestionAnswerVM>();
            foreach (QuizQuestion qq in quiz.QuizQuestions) {
                Questions.Add(qq.Question);
            }
        }
    }
}
