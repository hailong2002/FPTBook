using Microsoft.AspNetCore.Mvc;

namespace FPTBook.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
