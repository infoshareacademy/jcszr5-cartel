using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesPortalWebApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: CommentController1
        public ActionResult ShowAllComments(int movieId)
        {
            var comments = _commentService.GetAllComments(movieId);
            return View();
        }

        // GET: CommentController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommentController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommentController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CommentController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommentController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CommentController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommentController1/Delete/5
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
