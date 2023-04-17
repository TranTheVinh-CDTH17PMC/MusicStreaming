using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MusicStreaming.Interface;
using MusicStreaming.Models;
using MusicStreaming.Repository;

namespace MusicStreaming.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Route("Admin/Type")]
    public class TypeController : Controller
    {
        private ITypes types;
        public TypeController(ITypes _types)
        {
            types = _types;
        }
        // GET: TypeController
        [Route("")]
        [Route("Index")]
        public ActionResult Index()
        {
            IEnumerable<TypeViewModel> model = types.SelectAll().Select(
                item => new TypeViewModel
                {
                    Id = item.Id,
                    NameType = item.NameType,
                    IsDelete = item.IsDelete
                }).Where(x=>x.IsDelete == true);
            return View(model);
        }

        // GET: TypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Route("Create")]
        // GET: TypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeController/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(TypeViewModel model)
        {
            try
            {
                var _type = new Entitis.Type();
                _type.NameType = model.NameType;
                _type.IsDelete = true;
                types.Insert(_type);
                types.Save();
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TypeController/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int id)
        {
            var model = types.SelectById(id);
            return View(model);
        }

        // POST: TypeController/Edit/5
        [HttpPost]
        [Route("Edit")]
        public ActionResult Edit(int id, TypeViewModel model)
        {
            try
            {
                var _type = types.SelectById(id);
                _type.NameType = model.NameType;
                types.Update(_type);
                types.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: TypeController/Delete/5
        [HttpPost]
        [Route("Delete")]
        public ActionResult Delete(int IdDelete)
        {
            try
            {
                var _type = types.SelectById(IdDelete);
                _type.IsDelete = false;
                types.Update(_type);
                types.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
