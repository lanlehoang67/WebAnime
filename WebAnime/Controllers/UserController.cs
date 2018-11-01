using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAnime.Models;
namespace WebAnime.Controllers
{
    public class UserController : Controller
    {
        WebAnimeDBEntities db = new WebAnimeDBEntities();
        // GET: User
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(NguoiDung nd)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDungs.Add(nd);
                db.SaveChanges();
        
              
            }
            return RedirectToAction("TrangChu", "Home");
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            ViewBag.TaiKhoan = null;
           string taiKhoan = f["TaiKhoan"].ToString();
            string matKhau = f["MatKhau"].ToString();
            NguoiDung nd = db.NguoiDungs.SingleOrDefault(n => n.TaiKhoan == taiKhoan && n.MatKhau == matKhau);
            if (nd != null)
            {
             
              
                ViewBag.ThongBao = "Chúc mừng bạn đã đăng nhập thành công !";
                Session["TaiKhoan"] = taiKhoan;
              
                return RedirectToAction("TrangChu","Home");
            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";
            return View();
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("TrangChu", "Home");
        }
    }
}