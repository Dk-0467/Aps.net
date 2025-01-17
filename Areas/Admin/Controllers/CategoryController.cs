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
    public class CategoryController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();

        // GET: Admin/Category
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstCategory= new List<Category>();
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
                lstCategory = objWebsiteBanHangEntities.Categories.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                //lấy all sån phẩm trong bảng product
                lstCategory = objWebsiteBanHangEntities.Categories.ToList();
            }

            ViewBag.CurrentFilter = SearchString;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            lstCategory = lstCategory.OrderByDescending(n => n.Id).ToList();
            return View(lstCategory.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var objCategory = objWebsiteBanHangEntities.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(objCategory);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category objCategory)
        {
            try
            {
                if (objCategory.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                    string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objCategory.Avatar = fileName;
                    objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
                }
                objWebsiteBanHangEntities.Categories.Add(objCategory);
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
            var objCategory = objWebsiteBanHangEntities.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(objCategory);
        }

        [HttpPost]
        public ActionResult Delete(Category objCa)
        {
            var objCategory = objWebsiteBanHangEntities.Categories.Where(n => n.Id == objCa.Id).FirstOrDefault();

            // Kiểm tra nếu danh mục có liên kết với sản phẩm
            var linkedProducts = objWebsiteBanHangEntities.Products.Any(p => p.CategoryId == objCategory.Id);
            if (linkedProducts)
            {
                ViewBag.ErrorMessage = "Không thể xóa danh mục này vì đã có sản phẩm liên kết.";
                return View(objCategory);
            }

            // Xóa danh mục nếu không có liên kết
            objWebsiteBanHangEntities.Categories.Remove(objCategory);
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objCategory = objWebsiteBanHangEntities.Categories.Where(p => p.Id == id).FirstOrDefault();
            return View(objCategory);
        }

        [HttpPost]
        public ActionResult Edit(Category objCategory)
        {
            // Lấy danh mục hiện tại từ cơ sở dữ liệu
            var existingCategory = objWebsiteBanHangEntities.Categories.Find(objCategory.Id);

            if (existingCategory != null)
            {
                if (objCategory.ImageUpload != null && !string.IsNullOrEmpty(objCategory.ImageUpload.FileName))
                {
                    // Xử lý nếu có tải lên ảnh mới
                    string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                    string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                    fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + extension;
                    objCategory.Avatar = fileName;
                    objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
                }
                else
                {
                    // Giữ nguyên ảnh cũ
                    objCategory.Avatar = existingCategory.Avatar;
                }

                // Cập nhật thông tin danh mục
                objWebsiteBanHangEntities.Entry(existingCategory).CurrentValues.SetValues(objCategory);
                objWebsiteBanHangEntities.Entry(existingCategory).State = EntityState.Modified;

                objWebsiteBanHangEntities.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}