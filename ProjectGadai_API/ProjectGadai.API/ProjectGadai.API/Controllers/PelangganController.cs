using Microsoft.AspNetCore.Mvc;

namespace ProjectGadai.API.Controllers
{
    public class PelangganController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
