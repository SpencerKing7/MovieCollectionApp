using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollectionApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollectionApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieInputContext movieContext { get; set; } 

        // Constructor
        public HomeController(ILogger<HomeController> logger, MovieInputContext name)
        {
            _logger = logger;
            movieContext = name;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovie ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterMovie (MovieInputModel ar)
        {
            movieContext.Add(ar);
            movieContext.SaveChanges();

            return View("Confirmation", ar);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
