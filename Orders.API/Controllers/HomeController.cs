using Microsoft.AspNetCore.Mvc;

namespace Orders.API.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
