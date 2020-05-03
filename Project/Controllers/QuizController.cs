using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.Repo_s;

namespace Project.Web.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuizRepo quizRepo;

        public QuizController(IQuizRepo quizRepo) {
            this.quizRepo = quizRepo;
        }

        // GET: Quiz
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index() {
            var allQuizzes = await quizRepo.GetAllAsync();
            return View(allQuizzes);
        }

        // GET: Quiz/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Details(Guid id) {
            var quiz = await quizRepo.GetAsync(id);
            return View(quiz);
        }

        // GET: Quiz/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create() {
            return View();
        }

        // POST: Quiz/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection, Quiz quiz) {
            try {
                if (ModelState.IsValid) {
                    quizRepo.Create(quiz);
                    await quizRepo.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        // GET: Quiz/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(Guid id) {
            try {
                var quiz = await quizRepo.GetAsync(id);
                return View(quiz);
            } catch {

                return RedirectToAction(nameof(Edit));
            }
            
        }

        // POST: Quiz/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        // GET: Quiz/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Quiz/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid? id, IFormCollection collection) {
            try {
                if (ModelState.IsValid) {
                    if (id == null) {
                        throw new Exception("Bad Delete Request");
                    }
                    var quiz = await quizRepo.GetAsync(id);
                    quizRepo.Delete(quiz);
                    await quizRepo.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));

            } catch (Exception ex) {
                return View();
            }
        }
    }
}