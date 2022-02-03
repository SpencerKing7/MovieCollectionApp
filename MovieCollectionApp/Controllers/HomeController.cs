using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieInputContext movieContext { get; set; } 

        // Constructor
        public HomeController(MovieInputContext name)
        {
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
            ViewBag.Categories = movieContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult EnterMovie (MovieInputModel ar)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(ar);
                movieContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else  //if invalid
            {
                ViewBag.Categories = movieContext.Categories.ToList();

                return View();
            }  
        }

        public IActionResult MovieList()
        {
            var movies = movieContext.Responses.Include(c => c.Category).ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            var movie = movieContext.Responses.Single(m => m.MovieId == movieid);

            return View("EnterMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieInputModel ar)
        {
            movieContext.Update(ar);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = movieContext.Responses.Single(m => m.MovieId == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MovieInputModel ar)
        {
            movieContext.Responses.Remove(ar);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
