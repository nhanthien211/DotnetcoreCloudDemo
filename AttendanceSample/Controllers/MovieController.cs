using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSample.Entity;
using AttendanceSample.Service.DTO;
using AttendanceSample.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceSample.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListMovie()
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            var data = _movieService.GetAllMovie();
            return Json(new { draw = draw, recordsFiltered = data.Count, recordsTotal = data.Count, data = data });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieDto movieDto)
        {
            var result = _movieService.CreateMovie(movieDto);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View(movieDto);
        }

        [HttpGet]
        [Route("Movie/Detail/{id}")]
        public IActionResult Detail(int id)
        {
            var movie = _movieService.GetMovieInfo(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Update(Movie movie)
        {
            _movieService.UpdateMovie(movie);
            return RedirectToAction("Detail", new {id = movie.Id});
        }
    }
}