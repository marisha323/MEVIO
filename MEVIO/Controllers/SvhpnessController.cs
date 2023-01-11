using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class SvhpnessController : Controller
    {
        // GET: SvhpnessController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SvhpnessController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SvhpnessController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SvhpnessController/Create
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

        // GET: SvhpnessController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SvhpnessController/Edit/5
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

        // GET: SvhpnessController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SvhpnessController/Delete/5
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
