using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStreaming.Entitis;
using MusicStreaming.Interface;
using MusicStreaming.Models;
using MusicStreaming.Repository;

namespace MusicStreaming.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Route("Admin/Singer")]
    public class SingerController : Controller
    {
        private ISinger singer;
        private IWebHostEnvironment _iweb;
        public SingerController(ISinger _singer, IWebHostEnvironment iweb)
        {
            singer = _singer;
            _iweb = iweb;
        }
        // GET: SingerController
        [Route("")]
        [Route("Index")]
        public ActionResult Index()
        {
            IEnumerable<SingerViewModel> model = singer.SelectAll().Select(item => new SingerViewModel
            {
                Id = item.Id,
                ImgInfo = item.ImgInfo,
                NameSinger = item.NameSinger,
                IsDelete = item.IsDelete
            }).Where(x=>x.IsDelete == true);
            return View(model);
        }

        // GET: SingerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SingerController/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SingerController/Create
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create(SingerViewModel model, IFormFile file)
        {
            try
            {
                var saveimg = Path.Combine(_iweb.WebRootPath, "Content", "Img_Singer", file.FileName);
                string imgtext = Path.GetExtension(file.FileName);
                if(imgtext == ".jpg" || imgtext == ".png")
                {
                    using(var uploading = new FileStream(saveimg, FileMode.Create))
                    {
                        await file.CopyToAsync(uploading);
                    }
                }
                var _singer = new Singer();
                _singer.ImgInfo = file.FileName;
                _singer.NameSinger = model.NameSinger;
                _singer.IsDelete = true;
                singer.Insert(_singer);
                singer.Save();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: SingerController/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int id)
        {
            var model = singer.SelectById(id);
            return View(model);
        }

        // POST: SingerController/Edit/5
        [HttpPost]
        [Route("Edit")]
        public async Task<ActionResult> Edit(int id, SingerViewModel model, IFormFile file)
        {
            try
            {
                string nameimgnew;
                var _singer = singer.SelectById(id);
                if(file != null)
                {
                    if (_singer.ImgInfo != file.Name)
                    {
                        var saveimg = Path.Combine(_iweb.WebRootPath, "Content", "Img_Singer", file.FileName);
                        string imgtext = Path.GetExtension(file.FileName);
                        if (imgtext == ".jpg" || imgtext == ".png")
                        {
                            using (var uploading = new FileStream(saveimg, FileMode.Create))
                            {
                                await file.CopyToAsync(uploading);
                                nameimgnew = file.FileName;
                                _singer.ImgInfo = nameimgnew;
                            }
                        }
                    }
                }    
                _singer.NameSinger = model.NameSinger;
                singer.Update(_singer);
                singer.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: SingerController/Delete/5
        [Route("Delete")]
        [HttpPost]
        public ActionResult Delete(int IdDelete)
        {
            try
            {
                var _singer = singer.SelectById(IdDelete);
                _singer.IsDelete = false;
                singer.Update(_singer);
                singer.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
