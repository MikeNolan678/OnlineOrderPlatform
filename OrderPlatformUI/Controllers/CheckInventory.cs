using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;

namespace OrderPlatformUI.Controllers
{
    public class CheckInventory : Controller
    {
        // GET: CheckInventory
        public ActionResult Index()
        {
            return View();
        }

        // GET: CheckInventory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CheckInventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckInventory/Create
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

        // GET: CheckInventory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CheckInventory/Edit/5
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

        // GET: CheckInventory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckInventory/Delete/5
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
