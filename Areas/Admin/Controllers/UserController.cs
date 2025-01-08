using buiduckiem_aps.net.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace buiduckiem_aps.net.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();

        // GET: Admin/User
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstUser = new List<User>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                //lấy ds sản phẩm theo từ khóa tìm kiếm
                lstUser = objWebsiteBanHangEntities.Users.Where(n => n.LastName.Contains(SearchString)).ToList();
            }
            else
            {
                //lấy all sån phẩm trong bảng product
                lstUser = objWebsiteBanHangEntities.Users.ToList();
            }

            ViewBag.CurrentFilter = SearchString;
            //số lượng item của 1 trang = 4
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            lstUser = lstUser.OrderByDescending(n => n.Id).ToList();
            return View(lstUser.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var lstUser = objWebsiteBanHangEntities.Users.Where(n => n.Id == Id).FirstOrDefault();
            return View(lstUser);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var lstUser = objWebsiteBanHangEntities.Users.Where(n => n.Id == Id).FirstOrDefault();
            return View(lstUser);
        }

        [HttpPost]
        public ActionResult Delete(User objUser)
        {
            var lstUser = objWebsiteBanHangEntities.Users.Where(n => n.Id == objUser.Id).FirstOrDefault();
            objWebsiteBanHangEntities.Users.Remove(lstUser);
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User lstUser)
        {
            try
            {
                objWebsiteBanHangEntities.Users.Add(lstUser);
                objWebsiteBanHangEntities.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var lstUser = objWebsiteBanHangEntities.Users.Where(p => p.Id == id).FirstOrDefault();
            return View(lstUser);
        }

        [HttpPost]
        public ActionResult Edit(User lstUser)
        { 
            objWebsiteBanHangEntities.Entry(lstUser).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}