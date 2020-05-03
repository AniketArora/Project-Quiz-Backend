using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.Repo_s;
using System.Security.Claims;
using Project.Web.ViewModels;

namespace Project.Web.Views.Play
{
    public class PlayController : Controller
    {
        private readonly IQuizRepo quizRepo;
        private readonly ISubjectRepo subjectRepo;
        private readonly IUserQuizRepo userQuizRepo;
        private readonly IQuizAnswerRepo quizAnswerRepo;
        private readonly IAnswerRepo answerRepo;


        public PlayController(IQuizRepo quizRepo, ISubjectRepo subjectRepo, IUserQuizRepo userQuizRepo, IQuizAnswerRepo quizAnswerRepo, IAnswerRepo answerRepo) {
            this.quizRepo = quizRepo;
            this.subjectRepo = subjectRepo;
            this.userQuizRepo = userQuizRepo;
            this.quizAnswerRepo = quizAnswerRepo;
            this.answerRepo = answerRepo;
        }

        // GET: Indexpage of Quiz
        [Authorize]
        public async Task<IActionResult> Index() {
            var allQuizzes = await quizRepo.GetAllAsync();
            return View(allQuizzes);
        }

        // GET: QuizGame
        [Authorize]
        public async Task<IActionResult> Details(Guid id) {
            var userid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var UserQuiz = new UserQuiz {
                UserId = userid,
                QuizId = id
            };
            userQuizRepo.Create(UserQuiz);
            await userQuizRepo.SaveChangesAsync();

            var Quiz = await quizRepo.GetAsync(id);

            QuizQuestionAnswerVM vm = new QuizQuestionAnswerVM(answerRepo, Quiz) { UserQuizID = UserQuiz.Id};
            return View(vm);
        }

        // POST: QuizGame
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(IFormCollection collection, QuizQuestionAnswerVM quizQuestionAnswerVM) {
            try { 
                if (ModelState.IsValid) {
                    foreach (Question q in quizQuestionAnswerVM.Questions) {
                        var QuizAnswer = new QuizAnswer { UserQuizId = quizQuestionAnswerVM.UserQuizID, QuestionId = q.Id};
                        foreach (var answer in quizQuestionAnswerVM.SelectedAnswersString) {
                            QuizAnswer.AnswerId = Guid.Parse(answer);
                        }
                        quizAnswerRepo.Create(QuizAnswer);
                        await quizAnswerRepo.SaveChangesAsync();
                    }
                }
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }
    }
}