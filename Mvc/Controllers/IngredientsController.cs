using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class IngredientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
