using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class W1shController : Controller
    {
        // GET: W1shController
        public ActionResult Index()
        {
            return View();
        }

        // GET: W1shController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: W1shController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: W1shController/Create
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

        // GET: W1shController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: W1shController/Edit/5
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

        // GET: W1shController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: W1shController/Delete/5
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
