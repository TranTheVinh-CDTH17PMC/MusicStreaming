using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    [Route("Admin/Music")]
    public class MusicController : Controller
    {
        private IMusic music;
        private ITypes type;
        private ISinger singer;
        private IWebHostEnvironment _iweb;
        public MusicController(IMusic _music, ITypes _type, ISinger _singer, IWebHostEnvironment iweb)
        {
            music = _music;
            type = _type;
            singer = _singer;
            _iweb = iweb;
        }
        // GET: MusicController
        [Route("")]
        [Route("Index")]
        public ActionResult Index()
        {
            IEnumerable<MusicViewModel> model = music.SelectAll().Select(item => new MusicViewModel
            {
                Id = item.Id,
                IdSinger = item.IdSinger,
                ImgInfo = item.ImgInfo,
                IdType = item.IdType,
                NameType = GetNameType(item.IdType),
                NameSinger = GetNameSinger(item.IdSinger),
                IsDelete = item.IsDelete,
                CreateDate = item.CreateDate,
                LinkFile = item.LinkFile,
                NameMusic = item.NameMusic
            }).Where(x => x.IsDelete == true) ;
            return View(model);
        }
        public string GetNameSinger(int? id)
        {
            var name = singer.SelectById(id);
            return name.NameSinger;
        }
        public string GetNameType(int? id)
        {
            var name = type.SelectById(id);
            return name.NameType;
        }
        // GET: MusicController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Route("Create")]
        // GET: MusicController/Create
        public ActionResult Create()
        {
            ViewBag.ListType = type.SelectAll().Where(x => x.IsDelete == true);
            ViewBag.ListSinger = singer.SelectAll().Where(x => x.IsDelete == true);
            return View();
        }
        // POST: MusicController/Create
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create(MusicViewModel model, IFormFile fileimg, IFormFile filemp3)
        {
            try
            {
                string textimg = ChuyenThanhKhongDau(fileimg.FileName);
                string textmp3 = ChuyenThanhKhongDau(filemp3.FileName);
                var savemp3 = Path.Combine(_iweb.WebRootPath, "Content", "Link_Mp3", textmp3);
                string mp3text = Path.GetExtension(filemp3.FileName);
                if (mp3text == ".mp3")
                {
                    using (var uploading1 = new FileStream(savemp3, FileMode.Create))
                    {
                         filemp3.CopyTo(uploading1);
                    }
                }
                var saveimg = Path.Combine(_iweb.WebRootPath, "Content", "Img_Music", textimg);
                string imgtext = Path.GetExtension(fileimg.FileName);
                if (imgtext == ".jpg" || imgtext == ".png")
                {
                    using (var uploading = new FileStream(saveimg, FileMode.Create))
                    {
                        await fileimg.CopyToAsync(uploading);
                    }
                }
                
                var _music = new Music();
                _music.NameMusic = model.NameMusic;
                _music.IdSinger = model.IdSinger;
                _music.ImgInfo = textimg;
                _music.IdType = model.IdType;
                _music.IsDelete = true;
                _music.CreateDate = DateTime.Now.ToString();
                _music.LinkFile = textmp3;
                music.Insert(_music);
                music.Save();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }
        public static string ChuyenThanhKhongDau(string s)
        {
            string a =  DateTime.Now.ToString();
            s = a + s;
            if (string.IsNullOrEmpty(s) == true)
                return "";

            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').Replace(" ", "").Replace("/", "").Replace(":", "").ToLower();
        }
        [Route("Edit")]
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
        [Route("Delete")]
        // POST: MusicController/Delete/5
        [HttpPost]
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
