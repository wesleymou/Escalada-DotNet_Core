using Microsoft.AspNetCore.Mvc;

namespace Escalada.Controllers {
    public class ProviderController : Controller
    {
        public IActionResult Index (){
            return View();
        }
    }
}