using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.Repo_s;

namespace Project.Web.Controllers
{
    public class SubjectController : Controller {

        private readonly ISubjectRepo subjectRepo;

        public SubjectController(ISubjectRepo subjectRepo) {
            this.subjectRepo = subjectRepo;
        }

        // GET: Subject

        public async Task<IActionResult> Index()
        {
            var allSubjects = await subjectRepo.GetAllAsync();
            return View(allSubjects);
        }

        // GET: Subject/Details/5
        public async Task<ActionResult> Details(Guid id) {
            var subject = await subjectRepo.GetAsync(id);
            return View(subject);
        }

        // GET: Subject/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Subject/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection, Subject subject) {
            try {
                if (ModelState.IsValid) {
                    subjectRepo.Create(subject);
                    await subjectRepo.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        // GET: Subject/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Subject/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        // GET: Subject/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Subject/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid? id, IFormCollection collection) {
            try {
                try {
                    if (ModelState.IsValid) {
                        if (id == null) {
                            throw new Exception("Bad Delete Request");
                        }
                        var subject = await subjectRepo.GetAsync(id);
                        subjectRepo.Delete(subject);
                        await subjectRepo.SaveChangesAsync();
                    }
                    return RedirectToAction(nameof(Index));

                } catch (Exception ex) {

                    return View();
                }

                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }
    }
}