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
        [HttpGet]
        public async Task<IActionResult> Index() {
            var allQuizzes = await quizRepo.GetAllAsync();
            return View(allQuizzes);
        }

        // GET: QuizGame
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(Guid id) {
            var userid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var UserQuiz = new UserQuiz {
                UserId = userid,
                QuizId = id
            };
            userQuizRepo.Create(UserQuiz);
            await userQuizRepo.SaveChangesAsync();

            var Quiz = await quizRepo.GetAsync(id);

            QuizQuestionAnswerVM vm = new QuizQuestionAnswerVM(answerRepo, Quiz) { UserQuizID = UserQuiz.Id, TestVM = new TestVM { UserQuizId = UserQuiz.Id} };
            return View(vm);
        }

        // POST: QuizGame
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(IFormCollection collection, TestVM quizQuestionAnswerVM) {
            try {

                //  { UserQuizId: Guid , questions: [{ questionId: answerId} ,{ questionId: answerId}  ] ;  

                var quizAnswers = new List<QuizAnswer>();
                foreach (var item in quizQuestionAnswerVM.Test2VMs) {
                    quizAnswers.Add(new QuizAnswer() {
                        AnswerId = item.AnswerId,
                        QuestionId = item.QuestionId,
                        UserQuizId = quizQuestionAnswerVM.UserQuizId
                    });
                }
                quizAnswerRepo.SaveBulk(quizAnswers);
                await quizAnswerRepo.SaveChangesAsync();

                return RedirectToAction(nameof(Finish), "Play" ,quizAnswers);
            } catch (Exception ex){
                ex.InnerException.Message.ToString();
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Finish(List<QuizAnswer> quizAnswers) {
            return View(quizAnswers);
        }
    }
}