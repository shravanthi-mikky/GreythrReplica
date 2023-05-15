using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ReplicaGreythr.Controllers
{
    public class UserController : Controller
    {

        IUserBL iUserBL;
        public UserController(IUserBL iUserBL)
        {
            this.iUserBL = iUserBL;
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}
