using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusicStreaming.Areas.Admin.Controllers
{
    public class MusicController : Controller
    {
        // GET: MusicController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MusicController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MusicController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusicController/Create
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

        // GET: MusicController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MusicController/Edit/5
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

        // GET: MusicController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MusicController/Delete/5
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
