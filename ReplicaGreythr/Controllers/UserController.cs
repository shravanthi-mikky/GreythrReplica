using Microsoft.AspNetCore.Mvc;

namespace ReplicaGreythr.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
