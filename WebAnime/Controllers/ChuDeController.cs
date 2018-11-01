using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAnime.Models;
namespace WebAnime.Controllers
{
    public class ChuDeController : Controller
    {
        WebAnimeDBEntities db = new WebAnimeDBEntities();
        // GET: ChuDe
        public ActionResult ChuDePartial()
        {
            return PartialView(db.ChuDes.OrderBy(n => n.MaChuDe).ToList());
        }
        
        public ActionResult XemChuDe(string maChuDe = "")
        {
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaChuDe == maChuDe);
            ViewBag.ChuDe = cd.TenChuDe;
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
           var query = from s in db.Animes
                             from n in s.ChuDes
                             where n.MaChuDe==maChuDe
                             select s;
            List<Anime> listAnime = query.ToList();
            if (listAnime.Count == 0)
            {
                ViewBag.Anime = "không có anime nào thuộc chủ đề này";  
            }
            return View(listAnime);
        }
    }
}