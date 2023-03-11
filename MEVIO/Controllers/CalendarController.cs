using MEVIO.Models.BackendClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class CalendarController : Controller
    {
        // GET: CalendarController
        public ActionResult Index()
        {
            List<MonthGenerator> months = new List<MonthGenerator>();
            months = MonthGenerator.Fill();

            ViewBag.months = months;

            List<string> days = new List<string>(){ "Понед", "Вівто", "Серед", "Четве", "П'ятн", "Субот", "Неділ" };
            ViewBag.weekDays = days;
            return View();
        }

        // GET: CalendarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CalendarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalendarController/Create
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

        // GET: CalendarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CalendarController/Edit/5
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

        // GET: CalendarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CalendarController/Delete/5
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
