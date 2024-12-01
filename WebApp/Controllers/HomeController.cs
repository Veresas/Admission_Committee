using System.Diagnostics;
using Contracts.Interfaces;
using Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentManager studentManager;

        public HomeController(IStudentManager studentManager)
        {
            this.studentManager = studentManager;
        }

        public async Task<IActionResult> Index()
        {
            var students = studentManager.GetAll();
            var stats = studentManager.GetStats();

            await Task.WhenAll(students, stats);

            ViewData[nameof(IStudentStats)] = stats.Result;
            return View(students.Result);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            student.Id = Guid.NewGuid();
            await studentManager.Add(student);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var students = await studentManager.GetAll();
            var student = students.FirstOrDefault(p => p.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            var students = await studentManager.GetAll();
            var isStudent = students.FirstOrDefault(p => p.Id == id);
            if (isStudent == null)
            {
                return NotFound();
            }

            await studentManager.Edit(student);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await studentManager.Delete(id);
            if (result == false)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
