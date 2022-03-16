using Microsoft.AspNetCore.Mvc;

namespace MusicFestival.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}