using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MoviesAPI.Data;

namespace MoviesAPI.Controlers
{
    public class HomeController : Controller
    {

        private readonly MoviesService _movieService;
        public HomeController(MoviesService computerService)
        {
            _movieService = computerService;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            var movies = _movieService.GetAllMovies();
            return View(movies);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(string id)
        {
            var movies = _movieService.GetById(id);
            return View(movies);
        }

        // GET: HomeController/Create
        public ActionResult CreateAsync(Movie movie)
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Movie movie)
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
            Movie movie = await _movieService.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, Movie movie)
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
            await _movieService.Remove(id);
            return RedirectToAction("Index");
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
