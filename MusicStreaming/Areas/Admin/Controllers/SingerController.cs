﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusicStreaming.Areas.Admin.Controllers
{
    public class SingerController : Controller
    {
        // GET: SingerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SingerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SingerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SingerController/Create
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

        // GET: SingerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SingerController/Edit/5
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

        // GET: SingerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SingerController/Delete/5
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
