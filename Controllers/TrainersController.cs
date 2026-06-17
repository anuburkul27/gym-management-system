using Microsoft.AspNetCore.Mvc;
using GymManagementSystem.Models;

namespace GymManagementSystem.Controllers
{
    public class TrainersController : Controller
    {
        static List<Trainer> trainers = new List<Trainer>();

        public IActionResult Index(string searchString)
        {
            var data = trainers;

            if (!string.IsNullOrEmpty(searchString))
            {
                data = trainers
                    .Where(x => x.Name.Contains(searchString))
                    .ToList();
            }

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Trainer trainer)
        {
            trainers.Add(trainer);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var trainer = trainers.FirstOrDefault(x => x.Id == id);

            return View(trainer);
        }

        [HttpPost]
        public IActionResult Edit(Trainer trainer)
        {
            var data = trainers.FirstOrDefault(x => x.Id == trainer.Id);

            data.Name = trainer.Name;
            data.Specialization = trainer.Specialization;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var trainer = trainers.FirstOrDefault(x => x.Id == id);

            return View(trainer);
        }

        [HttpPost]
        public IActionResult Delete(Trainer trainer)
        {
            var data = trainers.FirstOrDefault(x => x.Id == trainer.Id);

            trainers.Remove(data);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var trainer = trainers.FirstOrDefault(x => x.Id == id);

            return View(trainer);
        }
    }
}