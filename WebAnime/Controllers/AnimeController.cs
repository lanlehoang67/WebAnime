using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAnime.Models;
namespace WebAnime.Controllers
{
    public class AnimeController : Controller
    {
        WebAnimeDBEntities db = new WebAnimeDBEntities();
        // GET: Anime
        public ActionResult AnimeMoiPartial()
        {
            
            return PartialView(db.Animes.OrderBy(n => n.MaPhim).ToList());
        }
        public ActionResult XemNhieuPartial()
        {
            return PartialView(db.Animes.Take(3).OrderBy(n => n.MaPhim).ToList());
        }
        public ActionResult XemAnime(int maPhim = 1,int tap=1)
        {
            
            ViewBag.TaiKhoan = Session["TaiKhoan"];
            Anime anime = db.Animes.SingleOrDefault(n => n.MaPhim == maPhim);
            List<Co> listCo = db.Coes.Where(n => n.Tap == tap).ToList();
            List<Co> list2 = db.Coes.Where(n => n.MaPhim == maPhim).ToList();
            int soTap = int.Parse( list2.Max(t => t.Tap).ToString());
            foreach(Co item in listCo)
            {
                if(anime.MaPhim == item.MaPhim)
                {
                    ViewBag.Tap = tap;
                    ViewBag.MaPhim = item.MaPhim;
                    ViewBag.Link = item.Link;
                    ViewBag.SoTap = soTap;
                    return View(anime);
                }
            }
            if (anime == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return null;
            
        }
        public ActionResult TimKiemAnimePartial()
        {
            return PartialView();
        }
        public JsonResult GetSearchValue(string search)
        {
            WebAnimeDBEntities db = new WebAnimeDBEntities();
            List<AnimeModel> allsearch = db.Animes.Where(x => x.TenPhim.Contains(search)).Select(x => new AnimeModel
            {
                MaPhim = x.MaPhim,
                TenPhim = x.TenPhim,
                AnhBia = x.AnhBia,
                MoTa = x.MoTa
            }).ToList();
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        
    }
}