using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrabalhoCRUD_MVC.Models;
using TrabalhoCRUD_MVC.Services;

namespace TrabalhoCRUD_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServices _services;
        public HomeController(IServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}