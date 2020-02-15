using Microsoft.AspNetCore.Mvc;

namespace Escalada.Controllers {
    public class CustomerController : Controller
    {
        public IActionResult Index (){
            return View();
        }
    }
}