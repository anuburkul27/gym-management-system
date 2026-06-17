using Microsoft.AspNetCore.Mvc;
using GymManagementSystem.Models;

namespace GymManagementSystem.Controllers
{
    public class MembersController : Controller
    {
        static List<Member> members = new List<Member>();

        public IActionResult Index(string searchString)
        {
            var data = members;

            if (!string.IsNullOrEmpty(searchString))
            {
                data = members
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
        public IActionResult Create(Member member)
        {
            members.Add(member);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var member = members.FirstOrDefault(x => x.Id == id);

            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(Member member)
        {
            var data = members.FirstOrDefault(x => x.Id == member.Id);

            data.Name = member.Name;
            data.Phone = member.Phone;
            data.MembershipType = member.MembershipType;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var member = members.FirstOrDefault(x => x.Id == id);

            return View(member);
        }

        [HttpPost]
        public IActionResult Delete(Member member)
        {
            var data = members.FirstOrDefault(x => x.Id == member.Id);

            bool v = members.Remove(item: data);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var member = members.FirstOrDefault(x => x.Id == id);

            return View(member);
        }
    }
}