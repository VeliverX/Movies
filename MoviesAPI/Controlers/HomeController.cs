using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MoviesAPI.Data;

namespace MoviesAPI.Controlers
{
    public class HomeController : Controller
    {

        private readonly MoviesService _movieService;
        public HomeController(MoviesService moviesService)
        {
            _movieService = moviesService;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            var movies = _movieService.GetAllMovies().Result;
            return View(movies);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(string id)
        {
            var movies = _movieService.GetById(id).Result;
            return View(movies);
        }

        // GET: HomeController/Create
        public ActionResult CreateAsync(Movies movie)
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Movies movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.Create(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: HomeController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            Movies movie = await _movieService.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, Movies movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.Update(id,movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: HomeController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            Movies movie = await _movieService.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(string id)
        {
                await _movieService.Remove(id);
                return RedirectToAction("Index");

        }
    }
}
