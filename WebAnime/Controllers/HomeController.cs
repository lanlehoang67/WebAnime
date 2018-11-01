using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAnime.Models;

namespace WebAnime.Controllers
{
    public class HomeController : Controller
    {
        WebAnimeDBEntities db = new WebAnimeDBEntities();
        // GET: Home
       
        public ActionResult TrangChu()
        {
            ViewBag.TaiKhoan = Session["TaiKhoan"];
            return View();
        }
       
    
    }
}