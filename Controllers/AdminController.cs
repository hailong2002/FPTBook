using FPTBook.Data;
using FPTBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FPTBook.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext context;

        public AdminController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [Route("/")]
        public IActionResult Index()
        {
            var admins = context.Admins.ToList();
            return View(admins);
        }

        public IActionResult Detail(int id)
        {
            var admin = context.Admins.Find(id);
            return View(admin);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(context.Admins.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Admin admin)
        {
            if(ModelState.IsValid)
            {
                //TempData["Message"] = "Edit information successfully !!!";
                context.Admins.Update(admin);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
           
        }
    }
}
