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
    public class BrandController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();

        // GET: Admin/Brand
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstBrand = new List<Brand>();
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
                lstBrand = objWebsiteBanHangEntities.Brands.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                //lấy all sån phẩm trong bảng product
                lstBrand = objWebsiteBanHangEntities.Brands.ToList();
            }

            ViewBag.CurrentFilter = SearchString;
            //số lượng item của 1 trang = 4
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            lstBrand = lstBrand.OrderByDescending(n => n.Id).ToList();
            return View(lstBrand.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var objBrand = objWebsiteBanHangEntities.Brands.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Brand objBrand)
        {
            try
            {
                if (objBrand.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                    string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objBrand.Avatar = fileName;
                    objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                objWebsiteBanHangEntities.Brands.Add(objBrand);
                objWebsiteBanHangEntities.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objBrand = objWebsiteBanHangEntities.Brands.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpPost]
        public ActionResult Delete(Brand objBra)
        {
            var objBrand = objWebsiteBanHangEntities.Brands.Where(n => n.Id == objBra.Id).FirstOrDefault();
            objWebsiteBanHangEntities.Brands.Remove(objBrand);
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objBrand = objWebsiteBanHangEntities.Brands.Where(p => p.Id == id).FirstOrDefault();
            return View(objBrand);
        }

        [HttpPost]
        public ActionResult Edit(Brand objBrand)
        {
            if (objBrand.ImageUpload != null && !string.IsNullOrEmpty(objBrand.ImageUpload.FileName))
            {
                string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                string extention = Path.GetExtension(objBrand.ImageUpload.FileName);
                fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + extention;
                objBrand.Avatar = fileName;
                objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }

            objWebsiteBanHangEntities.Entry(objBrand).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}